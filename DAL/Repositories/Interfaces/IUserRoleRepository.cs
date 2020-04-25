using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserRoleRepository 
    {
        void DeleteUserRole(Guid id);
        void EditUserRole(Guid id, ApplicationUserRole newRole);
        Task<IEnumerable<ApplicationUserRole>> GetAllUserRolesAsync();
        Task<ApplicationUserRole> GetUserRoleAsync(Guid id);
        Task<Guid> GetUserRoleIdAsync(string roleName);
        void AddUserRole(ApplicationUserRole newRole);
    }
}