using DAL.Context;
using DAL.Models.IdentityModels;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRoleRepository : Repository<UserRole>
    {

        private readonly ILogger<UserRoleRepository> _logger;

        public UserRoleRepository(LibraryDataBaseContext context, ILogger<UserRoleRepository> logger)
  : base(context, logger) 
        {
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

       
        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var userRoleList = await GetAllAsync();
            foreach (var userRole in userRoleList)
            {
                if (userRole.RoleName == name)
                {
                    _logger.LogInformation("Return user role id");
                    return userRole.RoleId;
                }
            }
            _logger.LogWarning("User role not found, return default");
            return default;
        }
    }
}
