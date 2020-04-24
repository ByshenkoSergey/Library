using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserRoleRepository 
    {
        Task DeleteUserRoleAsync(Guid id);
        Task EditUserRoleAsync(Guid id, ApplicationUserRole newRole);
        Task<IEnumerable<ApplicationUserRole>> GetAllUserRolesAsync();
        Task<ApplicationUserRole> GetUserRoleAsync(Guid id);
        Task<Guid> GetUserRoleIdAsync(string roleName);
        Task InsertUserRoleAsync(ApplicationUserRole newRole);
    }
}