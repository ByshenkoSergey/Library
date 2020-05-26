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

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapConfig _mapper;
        private readonly IAuthOptions _options;

        public UserService(IUnitOfWork unit, IMapConfig mapper, IAuthOptions options)
        {
            _unit = unit;
            _mapper = mapper;
            _options = options;
        }

        public void Dispose()
        {
            _unit.Dispose();
        }

        public async Task<NewUserDTO> GetUserDTOAsync(Guid userId)
        {
            var user = await _unit.UserRepository.GetAsync(userId);

            if (user == null)
            {
                return null;
            }

            var userDTO = _mapper.GetMapper().Map<NewUserDTO>(user);
            return userDTO;
        }


        public async Task<IEnumerable<NewUserDTO>> GetAllUsersDTOAsync()
        {
            try
            {
                IEnumerable<NewUserDTO> users = _mapper.GetMapper().Map<IEnumerable<User>, IEnumerable<NewUserDTO>>(await _unit.UserRepository.GetAllAsync());
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            try
            {
                _unit.UserRepository.Delete(userId);
                await _unit.SaveChangeAsync();
            }
            catch (NullReferenceException e)
            {
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
            }
            catch (ArgumentException e)
            {
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
                    throw new ValidationException("Such user login already exists", "");
                }

                if (user.Email == newUserDTO.Email)
                {
                    throw new ValidationException("Such user email already exists", "");
                }
            }


            try
            {
                var newUser = _mapper.GetMapper().Map<User>(newUserDTO);
                _unit.UserRepository.Add(newUser);
                await _unit.SaveChangeAsync();
                Guid id = await _unit.UserRepository.GetModelIdAsync(newUser.UserLogin);
                return id;
            }
            catch (ArgumentException e)
            {
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
                var response = new
                {
                    access_token = encodedJwt,
                    userId= await GetUserIdAsync(userLogin),
                    tokenExpiration = AuthOptions.lifeTime.ToString(),
                    userRole = user.UserRole

                };
                var json = JsonSerializer.Serialize(response);
                return json;
            }
            catch (InvalidLogginUserException e)
            {
                throw e;
            }
            catch (ValidationException e)
            {
                throw e;
            }

        }

        private async Task<Guid> GetUserIdAsync(string userLogin)
        {
            var userList = await GetAllUsersDTOAsync();
            foreach (var user in userList)
            {
                if (user.UserLogin == userLogin)
                {
                    return user.UserId;
                }
            }
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
                throw new InvalidLogginUserException("User not found");
            }
            else
            {
                if (user.UserPassword != password)
                {
                    throw new InvalidLogginUserException("Invalid password");
                }
            }

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
            return claimsIdentity;
        }
    }
}


