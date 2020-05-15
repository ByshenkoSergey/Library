using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("a2340560-97b5-4e89-bebe-a293f4321d9a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("b197d8e3-755d-45f5-a677-22bf6b439115"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("c277ac98-747f-473e-a655-a6209fa1b165"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("de6fef1c-6d3e-49ae-8ab1-5f02e416357c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "64a433d2-8e4c-45a3-8f9a-32f0f4dfa0e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "8aeae25c-4b87-4274-9881-95d673319b25");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "7dca1cd4-fddc-4b96-9abd-4c62b60c6f2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "1542ce22-ff6b-46eb-a309-199b1e4d634e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "ConcurrencyStamp",
                value: "b2616330-08dc-425a-b818-59b980b5e0c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "311ad101-982a-4d3c-b2b8-214ea25de99d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "ba09d3ae-78eb-4c9d-94af-a77d5627f438");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "c0896f21-eec1-4bc1-9d4a-e54a01aebab5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("b197d8e3-755d-45f5-a677-22bf6b439115"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "9c6ac3e9-6cbf-42a3-b25d-cfdfa431b26f", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("c277ac98-747f-473e-a655-a6209fa1b165"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "6ebc3ddb-deac-43ba-9759-70e98e06c3d1", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("a2340560-97b5-4e89-bebe-a293f4321d9a"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "c0390e5c-ccdf-4ff9-afd3-87c6bd43bc27", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("de6fef1c-6d3e-49ae-8ab1-5f02e416357c"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "889cd48a-c767-4b97-b123-2557087d06c3", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });
        }
    }
}
