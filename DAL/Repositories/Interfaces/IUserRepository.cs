using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository 
    {
        Task DeleteUserAsync(Guid id);
        Task EditUserAsync(Guid id, ApplicationUser newUser);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserAsync(Guid id);
        Task<Guid> GetUserIdAsync(string userName);
        Task InsertUserAsync(ApplicationUser newUser);
    }
}