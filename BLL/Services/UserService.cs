using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;
using DAL.UnitOfWork;
using BLL.DTOModels;
using DAL.Models.IdentityModels;
using BLL.Options;
using BLL.Services.Interfaces;
using BLL.Infrastructure.Mapping;
using BLL.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapConfig _mapper;
        private readonly IAuthOptions _options;
        private readonly ILogger<UserService> _logger;


        public UserService(IUnitOfWork unit, IMapConfig mapper, 
            IAuthOptions options, ILogger<UserService> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _options = options;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

       

        public async Task<NewUserDTO> GetUserDTOAsync(Guid userId)
        {
            var user = await _unit.UserRepository.GetAsync(userId);

            if (user == null)
            {
                _logger.LogWarning("User not found");
                return null;
            }

            var userDTO = _mapper.GetMapper().Map<NewUserDTO>(user);
            _logger.LogInformation("Return user DTO");
            return userDTO;
        }


        public async Task<IEnumerable<NewUserDTO>> GetAllUsersDTOAsync()
        {
            try
            {
                var userList = await _unit.UserRepository.GetAllAsync();
                var userListDTO = _mapper.GetMapper().Map<IEnumerable<User>, IEnumerable<NewUserDTO>>(userList);
                _logger.LogInformation("Return user list DTO");
                return userListDTO;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            try
            {
                _unit.UserRepository.Delete(userId);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("User is deleted");
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public async Task EditUserAsync(Guid userId, NewUserDTO newUserDTO)
        {
            try
            {
                var newUser = _mapper.GetMapper().Map<User>(newUserDTO);
                _unit.UserRepository.Edit(newUser, userId);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("User is puted");
            }
            catch (ArgumentException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public async Task<Guid> AddUserAsync(NewUserDTO newUserDTO)
        {
            var users = await GetAllUsersDTOAsync();
            foreach (var user in users)
            {
                if (user.UserLogin == newUserDTO.UserLogin)
                {

                    _logger.LogWarning("Such user login already exists");
                    throw new ValidationException("Such user login already exists", "");
                }

                if (user.Email == newUserDTO.Email)
                {
                    _logger.LogWarning("Such user email already exists");
                    throw new ValidationException("Such user email already exists", "");
                }
            }


            try
            {
                var newUser = _mapper.GetMapper().Map<User>(newUserDTO);
                _unit.UserRepository.Add(newUser);
                await _unit.SaveChangeAsync();
                var id = await _unit.UserRepository.GetModelIdAsync(newUser.UserLogin);
                _logger.LogInformation("Return user id");
                return id;
            }
            catch (ArgumentException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw new ValidationException(e.Message, "");
            }
        }

        public async Task<string> GetTokenAsync(string userLogin, string password)
        {
            try
            {
                var user = await GetUserAsync(userLogin, password);
                var identity = GetIdentity(user);
                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                                                issuer: AuthOptions.issuer,
                                                audience: AuthOptions.audience,
                                                notBefore: now,
                                                claims: identity.Claims,
                                                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.lifeTime)),
                                                signingCredentials: new SigningCredentials(_options.symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                                                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                _logger.LogInformation("Token is created"); 
                var response = new
                {
                    access_token = encodedJwt,
                    userId= await GetUserIdAsync(userLogin),
                    tokenExpiration = AuthOptions.lifeTime.ToString(),
                    userRole = user.UserRole

                };
                var json = JsonSerializer.Serialize(response);
                _logger.LogInformation("Return token and other informations");
                return json;
            }
            catch (InvalidLogginUserException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }

        }

        public void Dispose()
        {
            _unit.Dispose();
            _logger.LogInformation("User repository is disposed");
        }

        private async Task<Guid> GetUserIdAsync(string userLogin)
        {
            var userList = await GetAllUsersDTOAsync();
            foreach (var user in userList)
            {
                if (user.UserLogin == userLogin)
                {
                    _logger.LogInformation("Return user id");
                    return user.UserId;
                }
            }
            _logger.LogWarning("User not found");
            throw new ValidationException("User not found", "");

        }

        private async Task<NewUserDTO> GetUserAsync(string userName, string password)
        {
            var allUsers = await GetAllUsersDTOAsync();

            NewUserDTO user = null;

            foreach (var person in allUsers)
            {
                if (person.UserLogin == userName)
                {
                    user = person;
                    break;
                }
            }
            if (user == null)
            {
                _logger.LogWarning("User not found");
                throw new InvalidLogginUserException("User not found");
            }
            else
            {
                if (user.UserPassword != password)
                {
                    _logger.LogWarning("Invalid password");
                    throw new InvalidLogginUserException("Invalid password");
                }
            }

            _logger.LogInformation("Return user");
            return user;
        }

        private ClaimsIdentity GetIdentity(NewUserDTO user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserLogin),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            _logger.LogInformation("Return claims identity");
            return claimsIdentity;
        }
    }
}


