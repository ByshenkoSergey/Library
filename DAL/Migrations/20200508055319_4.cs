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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "fb25305a-3957-4943-bd39-214946388f4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "e1fa172a-7a47-4df2-b0f6-9860f62149a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "7f5d8466-c868-4b5b-ba53-fdaa4e1464a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "c179be1b-c924-44cc-a1ac-9d96e53eb806");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("719cd470-2991-4906-98fd-aa821a3c1d58"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "0caa0459-e3fa-4bf2-8ce5-6650bd938361", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("891a9328-01c0-47d2-be2c-f519c754ab06"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "8ee2429d-821d-4312-9649-c5f203ebcd4d", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("a959de51-be12-402a-a30f-18ef1a827b36"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "e3705d53-696e-4dc9-9f89-0ea35463f17c", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("5d8dff73-ec05-4088-90af-9cbe4cfb137f"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "fd2de556-374f-4c23-aa20-bc256ab3c354", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("5d8dff73-ec05-4088-90af-9cbe4cfb137f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("719cd470-2991-4906-98fd-aa821a3c1d58"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("891a9328-01c0-47d2-be2c-f519c754ab06"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("a959de51-be12-402a-a30f-18ef1a827b36"));

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
