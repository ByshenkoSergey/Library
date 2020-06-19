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

        public UserRoleRepository(LibraryDataBaseContext context)
: base(context)
        {

        }


        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var userRoleList = await GetAllAsync();
            foreach (var userRole in userRoleList)
            {
                if (userRole.RoleName == name)
                {

                    return userRole.RoleId;
                }
            }

            return default;
        }
    }
}
