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

        public UserRepository(LibraryDataBaseContext context)
  : base(context)
        {

        }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var userList = await GetAllAsync();
            foreach (var user in userList)
            {
                if (user.UserLogin == name)
                {

                    return user.UserId;
                }
            }

            return default;
        }
    }
}
