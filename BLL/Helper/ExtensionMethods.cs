using BLL.DTOModels;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<NewUserDTO> WithoutPasswords(this IEnumerable<NewUserDTO> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static NewUserDTO WithoutPassword(this NewUserDTO user)
        {
            user.UserPassword = null;
            return user;
        }
    }
}
