﻿using BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task DeleteUserAsync(Guid userId);
        Task EditUserAsync(Guid userId, NewUserDTO newUserDTO);
        Task<IEnumerable<NewUserDTO>> GetAllUsersDTOAsync();
        Task<NewUserDTO> GetUserDTOAsync(Guid userId);
        Task InsertUserAsync(NewUserDTO newUserDTO);
        Task<string> GetTokenAsync(string login, string password);
    }
}