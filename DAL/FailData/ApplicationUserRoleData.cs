using DAL.Models.IdentityModels;
using System;
using System.Collections.Generic;

namespace DAL.FailData
{
    internal class ApplicationUserRoleData
    {
      
        public static IEnumerable<UserRole> GetApplicationUserRoleData()
        {
            yield return new UserRole
            {
                RoleId = new Guid("12354898745632154895123654879878"),
                RoleName = "Admin"
            };

            yield return new UserRole
            {
                RoleId = new Guid("a75489d78542315ff961a254892c8a32"),
                RoleName = "User"
            };

            yield return new UserRole
            {
                RoleId = new Guid("a75483378541515ff961a25489212a32"),
                RoleName = "SuperUser"
            };

            yield return new UserRole
            {
                RoleId = new Guid("123598765423156489578215647acdfa"),
                RoleName = "Moderator"
            };

        }
    }
}