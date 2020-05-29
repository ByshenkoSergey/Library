using DAL.Context;
using DAL.Models.IdentityModels;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(LibraryDataBaseContext context, ILogger<UserRepository> logger)
  : base(context, logger) 
        {
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }
       
        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var userList = await GetAllAsync();
            foreach (var user in userList)
            {
                if (user.UserLogin == name)
                {
                    _logger.LogInformation("Return user id");
                    return user.UserId;
                }
            }
            _logger.LogWarning("User not found, return default");
            return default;
        }
    }
}
