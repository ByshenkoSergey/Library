using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("3e4a92b0-440c-4337-813e-a0f3dd2bf53a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("71cb26a1-e65c-4d43-9f66-cda33056f232"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("e5dbc6e3-e4f0-436c-9e9e-b9e4237cbb61"));

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Books",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "e60e2f3a-11ba-4ec1-9982-fbdf5129192e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "cf9c7424-5ef0-4b48-97f4-03fd8facec8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "52a93016-d046-41ef-951f-76e75dd27bd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "e4cc4a55-1a06-49d0-9476-60bb824a4fa7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("286d81c9-ef6e-4670-9a81-7c01be151915"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "0eb2b2f9-02e1-4be8-a8bb-4e2037a4131b", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("f6d4d858-ed87-4a47-895d-3f192557964b"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "15eae353-5645-4cfc-a270-44ce94562832", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("73614ed2-0752-4770-8151-5e06c72c9648"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "1ed5d939-584f-4973-98e4-2c787b83f570", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                column: "ContentType",
                value: "text/plain");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                column: "ContentType",
                value: "text/plain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("286d81c9-ef6e-4670-9a81-7c01be151915"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("73614ed2-0752-4770-8151-5e06c72c9648"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("f6d4d858-ed87-4a47-895d-3f192557964b"));

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "19b4110e-bf1a-477b-8cb2-7a3c3bbc7dcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "b76dd0a8-7317-47e2-b54c-56a026e8a199");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "5f5cd6e7-25bd-46dc-a334-13ce62fd5b4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "7924cca0-28aa-4c99-afd1-570a702206ce");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("e5dbc6e3-e4f0-436c-9e9e-b9e4237cbb61"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "079b859b-4044-46b6-b795-cdaf72b85315", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("71cb26a1-e65c-4d43-9f66-cda33056f232"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "3eced11b-5e26-4b85-b979-ad208ac52314", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("3e4a92b0-440c-4337-813e-a0f3dd2bf53a"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "4751fc89-e387-4cf6-8216-21c845c15db7", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" }
                });
        }
    }
}
