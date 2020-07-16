using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FailData
{
    public class ApplicationUserData
    {
        private static readonly List<UserRole> _roleList = ApplicationUserRoleData.GetApplicationUserRoleData().ToList();

        private static Guid GetUserRoleGuid(string roleName)
        {
            Guid result = default;
            foreach (var role in _roleList)
            {
                if (role.RoleName == roleName)
                {
                    result = role.RoleId;
                    break;
                }
            }
            return result;
        }

        public static IEnumerable<User> GetApplicationUserData()
        {
            yield return new User
            {
                UserId = Guid.NewGuid(),
                UserLogin = "admin",
                UserFirstName = "Vova",
                UserLastName = "Pupkin",
                UserPassword = "admin",
                UserYearsOld = "19",
                PhoneNumber = "095-987-35-67",
                Email = "pupkin@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("Admin"),
            };

            yield return new User
            {
                UserId = Guid.NewGuid(),
                UserLogin = "moderator",
                UserFirstName = "Sergey",
                UserLastName = "Petrov",
                UserPassword = "moderator",
                UserYearsOld = "31",
                PhoneNumber = "095-987-00-12",
                Email = "petrov@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("Moderator"),
            };

            yield return new User
            {
                UserId = Guid.NewGuid(),
                UserLogin = "user",
                UserFirstName = "Taras",
                UserLastName = "Ivanov",
                UserPassword = "user",
                UserYearsOld = "52",
                PhoneNumber = "095-989-11-11",
                Email = "ivanov@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("User"),
            };

            yield return new User
            {
                UserId = Guid.NewGuid(),
                UserLogin = "superuser",
                UserFirstName = "Andrey",
                UserLastName = "Sidorov",
                UserPassword = "superuser",
                UserYearsOld = "52",
                PhoneNumber = "095-989-12-12",
                Email = "sidorov@gmail.com",
                ApplicationUserRoleId = GetUserRoleGuid("SuperUser"),
            };
        }
    }
}