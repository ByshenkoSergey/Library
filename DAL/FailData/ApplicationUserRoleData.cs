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
                RoleName = "Admin",
                RoleInfo = "Key challenges and opportunities:\n 1. Chenge users role;\n 2. View all roles;\n" +
                "3. View all users;\n 4. Delete user;\n 5. Bun user;\n 6. Change your profile;"
            };

            yield return new UserRole
            {
                RoleId = new Guid("a75489d78542315ff961a254892c8a32"),
                RoleName = "User",
                 RoleInfo = "Key challenges and opportunities:\n 1. Chenge your profile;\n 2. View all books;\n" +
                "3. Serch books;\n 4. View author info;\n 5. View publisher info;\n 6. Read book;\n"
            };

            yield return new UserRole
            {
                RoleId = new Guid("a75483378541515ff961a25489212a32"),
                RoleName = "SuperUser",
                 RoleInfo = "Key challenges and opportunities:\n 1. Chenge your profile;\n 2. View all books;\n" +
                "3. Serch books;\n 4. View author info;\n 5. View publisher info;\n 6. Read book;\n 7. download book;\n" +
                " 8. Delete your profile;\n"
            };

            yield return new UserRole
            {
                RoleId = new Guid("123598765423156489578215647acdfa"),
                RoleName = "Moderator",
                 RoleInfo = "Key challenges and opportunities:\n 1. Chenge your profile;\n 2. View all books;\n" +
                "3. View all authors;\n 4. View all publishers;\n 5. View publisher info;\n 6. View author info;\n" +
                "7. Read book;\n 8. Read book;\n 9. Add book;\n 10. Change book;\n 11. Change author;\n 12. Change publisher;\n" +
                "13. Delete book;\n 14. Delete author;\n 15. Delete publisher;\n 16. Serch books;\n 17. Serch author;\n 18. Serch publisher;\n"
            };

        }
    }
}