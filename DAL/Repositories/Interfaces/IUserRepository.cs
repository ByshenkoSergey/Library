using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository 
    {
        void DeleteUser(Guid id);
        void EditUser(Guid id, ApplicationUser newUser);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserAsync(Guid id);
        Task<Guid> GetUserIdAsync(string userName);
        void AddUser(ApplicationUser newUser);
    }
}