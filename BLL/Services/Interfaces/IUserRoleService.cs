using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserRoleService : IDisposable
    {
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoleDTOAsync();
    }
}