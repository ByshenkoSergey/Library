using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("1de87255-2f09-4b8f-a244-ea98e9dc887e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("7db775c1-9f7e-4fbf-ba83-574895d3286d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("cff037eb-5f16-4e3f-a135-bfa46ad23de8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("f6f82326-3e37-4a48-a343-4b19d5fc19c8"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "cf09473d-0d38-4225-9b64-fdcf8650d834");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "9dffabe7-17c7-42fc-b810-af915d2a157b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "cd96b032-1320-4e07-b256-c10817d96e10");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "d4672fc8-4c92-426c-a9ab-c6e936f26909");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("2f554c89-ea85-4562-9627-c20bfd288ce7"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "50e7c8b0-e9fc-4c0c-bc06-88f426dd223b", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("f68e57e6-4ec9-4c8a-863d-4b112f011ee5"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "e915f84a-67d9-4180-8d1f-505f7fdced1c", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("d6a78dae-f8eb-418b-8a81-dbf09a724375"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "e4c322ee-9675-4140-9239-4d508a5698b1", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("68964b6d-77d7-4b44-a711-994324c3a286"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "43882990-088b-4f6e-8125-c0c5970f2b17", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Нello cat.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Black sea.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Square World.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Happy bird.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Black dog.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/New spring.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Merry.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                column: "FilePath",
                value: "wwwroot/BookLibrary/Little snake.txt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("2f554c89-ea85-4562-9627-c20bfd288ce7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("68964b6d-77d7-4b44-a711-994324c3a286"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("d6a78dae-f8eb-418b-8a81-dbf09a724375"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("f68e57e6-4ec9-4c8a-863d-4b112f011ee5"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "bf11c7cd-114f-4105-b4f8-db616bd15448");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "812e8ce0-a8b3-4593-a1f0-905826d4e8a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "e7d8bc9e-8663-4de4-8894-3144f88bfd01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "41941719-ee94-4a41-8993-f600a080ac66");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("cff037eb-5f16-4e3f-a135-bfa46ad23de8"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "c0e9ea72-86e2-4b39-b1cd-a862f4c0a10f", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("1de87255-2f09-4b8f-a244-ea98e9dc887e"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "9cbf9444-74e6-4bc1-acaa-20836f135276", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("f6f82326-3e37-4a48-a343-4b19d5fc19c8"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "c25bd226-b3c1-4dd8-b342-a3905e4d79c4", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("7db775c1-9f7e-4fbf-ba83-574895d3286d"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "5f35cba4-e399-4bdc-95ab-27d012f8cb1d", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"),
                column: "FilePath",
                value: "BookLibrary/Нello cat.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                column: "FilePath",
                value: "BookLibrary/Black sea.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                column: "FilePath",
                value: "BookLibrary/Square World.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                column: "FilePath",
                value: "BookLibrary/Happy bird.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                column: "FilePath",
                value: "BookLibrary/Black dog.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                column: "FilePath",
                value: "BookLibrary/New spring.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                column: "FilePath",
                value: "BookLibrary/Merry.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                column: "FilePath",
                value: "BookLibrary/Little snake.txt");
        }
    }
}
