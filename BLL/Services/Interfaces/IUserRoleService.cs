using BLL.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserRoleService 
    {
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoleDTOAsync();
    }
}