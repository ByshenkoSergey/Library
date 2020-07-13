using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService 
    {
        Task DeleteUserAsync(Guid userId);
        Task EditUserAsync(Guid userId, NewUserDTO newUserDTO);
        Task<IEnumerable<NewUserDTO>> GetAllUsersDTOAsync();
        Task<NewUserDTO> GetUserDTOAsync(Guid userId);
        Task<Guid> AddUserAsync(NewUserDTO newUserDTO);
        Task<string> GetTokenAsync(string login, string password);
    }
}