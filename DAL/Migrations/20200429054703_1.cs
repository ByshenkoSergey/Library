using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("08207260-3b2a-435c-952c-69b6b2f429f7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("0a642917-b2d0-47ad-ac60-51624661f1a7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("78e6409f-b429-49ad-8b2d-ae2ff2715ce7"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "855b5a8d-83c2-4331-b736-9896852457e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "9305632a-bf59-4d6c-b243-8719031a823d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "f7006098-5060-43d0-bf1c-b8e109b66fec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "1a42fdb1-fba2-4fcf-98ba-3adde0508e6b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("08207260-3b2a-435c-952c-69b6b2f429f7"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "e86d8c14-e310-4f29-9985-aaed9e1409a8", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("78e6409f-b429-49ad-8b2d-ae2ff2715ce7"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "b99660cd-7ca1-4823-a287-ff7d984a742b", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("0a642917-b2d0-47ad-ac60-51624661f1a7"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "e38abc0f-96ca-4f98-8a18-9e6bc76c0f83", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" }
                });
        }
    }
}
