using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("0b882bc1-48b0-42c6-ae48-01ebd2c8615b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("3205c51c-4cc7-418d-84b2-8e7d12ea3507"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("86824418-b84d-41f6-9bbb-24618f13eb23"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("c6733bb3-6f8e-4334-8c0f-4423f872ec7d"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "11e0b360-6a12-4713-ac7c-336c46ae179d", @"Key challenges and opportunities:
 1. Chenge users role;
 2. View all roles;
3. View all users;
 4. Delete user;
 5. Bun user;
 6. Change your profile;" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "a8c8df85-f0a2-48c6-a337-a3a40f74267b", @"Key challenges and opportunities:
 1. Chenge your profile;
 2. View all books;
3. View all authors;
 4. View all publishers;
 5. View publisher info;
 6. View author info;
7. Read book;
 8. Read book;
 9. Add book;
 10. Change book;
 11. Change author;
 12. Change publisher;
13. Delete book;
 14. Delete author;
 15. Delete publisher;
 16. Serch books;
 17. Serch author;
 18. Serch publisher;
" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "8611cd69-ffb5-4adb-b92e-9de639585265", @"Key challenges and opportunities:
 1. Chenge your profile;
 2. View all books;
3. Serch books;
 4. View author info;
 5. View publisher info;
 6. Read book;
 7. download book;
 8. Delete your profile;
" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "9f658a0c-0f09-46d8-983f-fae1c257efe5", @"Key challenges and opportunities:
 1. Chenge your profile;
 2. View all books;
3. Serch books;
 4. View author info;
 5. View publisher info;
 6. Read book;
" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("a4f8054e-344c-42e8-bca5-2cad0a3b4860"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "57148dd6-094b-4154-a4c6-c83897c78131", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("1a0f6018-6c61-4457-af72-9a1bac27de52"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "c437238c-9615-4bf0-938c-987b0b4bf6c2", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("5c6bffb7-1ab9-48db-827c-f2403d50821e"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "53bd103e-ab73-48b1-ac9d-0d1c3af235ae", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("a3c2b89a-1a24-4795-93e9-96b34e924830"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "993fc21a-e2af-4102-b4b9-cb4055947eeb", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("1a0f6018-6c61-4457-af72-9a1bac27de52"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("5c6bffb7-1ab9-48db-827c-f2403d50821e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("a3c2b89a-1a24-4795-93e9-96b34e924830"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("a4f8054e-344c-42e8-bca5-2cad0a3b4860"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "64a433d2-8e4c-45a3-8f9a-32f0f4dfa0e6", @"Key challenges and opportunities:
 1. Chenge users role;
 2. View all roles;
3. View all users;
 4. Delete user;
 5. Bun user;
 6. Change your profile;" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "8aeae25c-4b87-4274-9881-95d673319b25", @"Key challenges and opportunities:
 1. Chenge your profile;
 2. View all books;
3. View all authors;
 4. View all publishers;
 5. View publisher info;
 6. View author info;
7. Read book;
 8. Read book;
 9. Add book;
 10. Change book;
 11. Change author;
 12. Change publisher;
13. Delete book;
 14. Delete author;
 15. Delete publisher;
 16. Serch books;
 17. Serch author;
 18. Serch publisher;
" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "7dca1cd4-fddc-4b96-9abd-4c62b60c6f2c", @"Key challenges and opportunities:
 1. Chenge your profile;
 2. View all books;
3. Serch books;
 4. View author info;
 5. View publisher info;
 6. Read book;
 7. download book;
 8. Delete your profile;
" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                columns: new[] { "ConcurrencyStamp", "RoleInfo" },
                values: new object[] { "1542ce22-ff6b-46eb-a309-199b1e4d634e", @"Key challenges and opportunities:
 1. Chenge your profile;
 2. View all books;
3. Serch books;
 4. View author info;
 5. View publisher info;
 6. Read book;
" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("0b882bc1-48b0-42c6-ae48-01ebd2c8615b"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "f8b1b210-fa19-4f31-af36-e1bc93303bff", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("c6733bb3-6f8e-4334-8c0f-4423f872ec7d"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "044d652a-9115-42d7-820b-5db80e83e45d", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("86824418-b84d-41f6-9bbb-24618f13eb23"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "298ec7be-651e-49cd-bf61-7885f705adda", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("3205c51c-4cc7-418d-84b2-8e7d12ea3507"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "303ccc82-1432-4119-8900-ce906a8530dd", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });
        }
    }
}
