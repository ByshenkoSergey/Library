using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserRoleService : IDisposable
    {
        Task<Guid> AddUserRoleAsync(UserRoleDTO userRoleDTO);
        Task DeleteUserRoleAsync(Guid id);
        Task PutUserRoleAsync(Guid id, UserRoleDTO userRoleDTO);
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoleDTOAsync();
        Task<UserRoleDTO> GetUserRoleDTOAsync(Guid id);
    }
}