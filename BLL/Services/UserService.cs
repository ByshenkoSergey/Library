﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;
using DAL.UnitOfWork;
using BLL.DTOModels;
using BLL.Infrastructure;
using DAL.Models.IdentityModels;
using BLL.Options;
using BLL.Helper;
using BLL.Services.Interfaces;
using BLL.Infrastructure.Mapping;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unit;
        private IMapConfig _mapper;
        private IAuthOptions _options;

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
                throw new ValidationException("User not found", "");
            }

            var userDTO = _mapper.GetMapper().Map<NewUserDTO>(user);
            return userDTO.WithoutPassword();
        }


        public async Task<IEnumerable<NewUserDTO>> GetAllUsersDTOAsync()
        {
            try
            {
                IEnumerable<NewUserDTO> users = _mapper.GetMapper().Map<IEnumerable<User>, IEnumerable<NewUserDTO>>(await _unit.UserRepository.GetAllAsync());
                return users.WithoutPasswords();
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
            try
            {
                var newUser = _mapper.GetMapper().Map<User>(newUserDTO);
                _unit.UserRepository.Add(newUser);
                await _unit.SaveChangeAsync();
                Guid id = await _unit.UserRepository.GetModelIdAsync(newUser.UserName);
                return id;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public async Task<string> GetTokenAsync(string userName, string password)
        {
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
                                                signingCredentials: new SigningCredentials(_options.symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
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