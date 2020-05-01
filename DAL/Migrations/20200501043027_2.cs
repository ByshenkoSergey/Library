using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("2b36567d-eb39-42fd-b04c-57c127f9b321"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("3f60dd3d-7641-4783-b621-e82278c2dba2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("a1f9f529-69bf-496c-9257-b67f58697d85"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "94ea46c9-3e7d-4064-9ba6-dfdf886612b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "3c041d23-b631-4e36-9d45-e49f0527ec54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "daed8168-2801-4c7a-a57e-31deaee68d39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "ed906d3b-5e44-4735-8518-a97cb2309e70");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("3dc8a6f3-7ed3-4f5d-bcd1-5491b675e0ba"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "59cd80fd-56f6-4529-b8c3-d988c954974c", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("52da52e2-d1a4-49d8-ac5d-ff6205c0daec"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "110c49ea-27be-4d64-89b0-2acbd1dd8855", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("e4ddab7d-5b54-4683-9f0d-a3bc50bceee3"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "c31047cb-dd58-4a84-b7e6-3631a181f200", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("3dc8a6f3-7ed3-4f5d-bcd1-5491b675e0ba"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("52da52e2-d1a4-49d8-ac5d-ff6205c0daec"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("e4ddab7d-5b54-4683-9f0d-a3bc50bceee3"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "73a16c92-7128-49d3-9d2c-cad13b9721f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "721f79fd-a595-4eae-8318-d95fb665b5f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "97395931-02d1-4e2f-84f7-2a6f7343a3e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "5b5a2ce0-7703-4707-80f1-c589ff37898d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("2b36567d-eb39-42fd-b04c-57c127f9b321"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "201fb5fb-2218-4272-b067-49cf7887aa87", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("a1f9f529-69bf-496c-9257-b67f58697d85"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "eea85a2c-97ff-4151-bd04-ea32e3613a8c", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("3f60dd3d-7641-4783-b621-e82278c2dba2"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "7693ead1-9377-4bb8-9ee1-b0e8a82795d3", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" }
                });
        }
    }
}
