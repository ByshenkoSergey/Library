using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;
using BL.Service.Interfaces;
using DAL.UnitOfWork;
using BL.DTOModels;
using BL.Infrastructure;
using DAL.Models.IdentityModels;
using BL.Options;

namespace BL.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unit;
        private IMapConfig _mapper;
        private bool _disposed;

        public UserService(IUnitOfWork unit, IMapConfig mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unit.Dispose();
                }
            }
            _disposed = true;

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<NewUserDTO> GetUserDTOAsync(Guid userId)
        {
            if (userId == null)
            {
                throw new ValidationException("User id is not valid!", "");
            }

            try
            {
                var user = await _unit.UserRepository.GetUserAsync(userId);

                if (user == null)
                {
                    throw new ValidationException("User is not serch", "");
                }

                return new NewUserDTO
                {
                    UserId = userId,
                    UserLogin = user.UserLogin,
                    UserPassword = user.UserPassword,
                    UserFirstName = user.UserFirstName,
                    UserLastName = user.UserLastName,
                    UserYearsOld = user.UserYearsOld,
                    UserRole = user.ApplicationUserRole.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<NewUserDTO>> GetAllUsersDTOAsync()
        {
            try
            {
                return _mapper.GetMapper().Map<IEnumerable<ApplicationUser>, IEnumerable<NewUserDTO>>(await _unit.UserRepository.GetAllUsersAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task DeleteUserAsync(Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("User id is null");
            }

            try
            {
                _unit.UserRepository.DeleteUser(userId);
                await _unit.SaveChangeAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditUserAsync(Guid userId, NewUserDTO newUserDTO)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("User id null");
            }
            if (newUserDTO == null)
            {
                throw new ArgumentNullException("New user is null");
            }

            try
            {
                var newUser = new ApplicationUser
                {
                    UserId = userId,
                    UserLogin = newUserDTO.UserLogin,
                    UserPassword = newUserDTO.UserPassword,
                    UserFirstName = newUserDTO.UserFirstName,
                    UserLastName = newUserDTO.UserLastName,
                    UserYearsOld = newUserDTO.UserYearsOld,
                    ApplicationUserRoleId = await _unit.UserRepository.GetUserIdAsync(newUserDTO.UserRole),
                    Email = newUserDTO.Email,
                    PhoneNumber = newUserDTO.PhoneNumber

                };

                _unit.UserRepository.EditUser(userId, newUser);
                await _unit.SaveChangeAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertUserAsync(NewUserDTO newUserDTO)
        {
            if (newUserDTO == null)
            {
                throw new ArgumentNullException("New user is null");
            }
                        try
            {
                var newUser = new ApplicationUser
                {
                    UserLogin = newUserDTO.UserLogin,
                    UserPassword = newUserDTO.UserPassword,
                    UserFirstName = newUserDTO.UserFirstName,
                    UserLastName = newUserDTO.UserLastName,
                    UserYearsOld = newUserDTO.UserYearsOld,
                    ApplicationUserRoleId = await _unit.UserRepository.GetUserIdAsync(newUserDTO.UserRole),
                    Email = newUserDTO.Email,
                    PhoneNumber = newUserDTO.PhoneNumber
                };

                _unit.UserRepository.AddUser(newUser);
                await _unit.SaveChangeAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<string> GetTokenAsync(string userName, string password)
        {
            if (userName == null)
            {
                throw new ValidationException("user name is null", "");
            }

            if (password == null)
            {
                throw new ValidationException("password is null", "");
            }

            try
            {
                var identity = await GetIdentityAsync(userName, password);

                if (identity == null)
                {
                    throw new ValidationException("Invalid username or password.", "");
                }

                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                                                issuer: AuthOptions.issuer,
                                                audience: AuthOptions.audience,
                                                notBefore: now,
                                                claims: identity.Claims,
                                                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.lifeTime)),
                                                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                                                );

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name
                };

                var json = JsonSerializer.Serialize(response);

                return json;
            }
            catch (Exception)
            {

                throw;
            }


        }


        private async Task<ClaimsIdentity> GetIdentityAsync(string userName, string password)
        {
            var allUsers = await GetAllUsersDTOAsync();
            NewUserDTO user = null;

            foreach (var person in allUsers)
            {
                if (person.UserLogin == userName && person.UserPassword == password)
                {
                    user = person;
                    break;
                }

            }

            if (user != null)
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

            return null;
        }



    }
}
