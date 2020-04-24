using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FailData
{
    public class ApplicationUserData
    {
        private static List<ApplicationUserRole> roleList = ApplicationUserRoleData.GetApplicationUserRoleData().ToList();

        
        private static Guid GetUserRoleGuid(string roleName)
        {
            Guid result = default;
            foreach (var role in roleList)
            {
                if (role.RoleName == roleName)
                {
                    result = role.RoleId;
                    break;
                }
            }
            return result;
        }

        public static IEnumerable<ApplicationUser> GetApplicationUserData()
        {
            yield return new ApplicationUser
            {
                UserId = Guid.NewGuid(),
                UserLogin = "Pupkin@gmail.com",
                UserFirstName = "Vova",
                UserLastName = "Pupkin",
                UserPassword = "1111",
                UserYearsOld = "19",
                PhoneNumber = "095-987-35-67",
                Email = "pupkin@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("Admin"),
            };

            yield return new ApplicationUser
            {
                UserId = Guid.NewGuid(),
                UserLogin = "Petrov@gmail.com",
                UserFirstName = "Sergey",
                UserLastName = "Petrov",
                UserPassword = "2222",
                UserYearsOld = "31",
                PhoneNumber = "095-987-00-12",
                Email = "petrov@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("Moderator"),
            };

            yield return new ApplicationUser
            {
                UserId = Guid.NewGuid(),
                UserLogin = "Ivanov@gmail.com",
                UserFirstName = "Taras",
                UserLastName = "Ivanov",
                UserPassword = "3333",
                UserYearsOld = "52",
                PhoneNumber = "095-989-11-11",
                Email = "ivanov@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("User"),
            };


        }
    }
}