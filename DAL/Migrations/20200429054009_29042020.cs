using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _29042020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("d0a5c2b9-7df8-4f61-818a-308e2831de3d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("da74cd00-c6ee-4ab6-9dee-719ec11f3648"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("df156296-847a-4edb-8dc6-b7fe5cb7f55a"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "66575127-cf0c-493a-b277-33255af5686d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "2c7cb254-3c98-4102-b38e-10dbc18e0efc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "106203bf-00f5-452c-993b-1d7bbc9e23fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "d811b21c-a1ca-4e4e-8127-113fda3ff1eb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("12561c57-8647-47a4-bded-3e3c8345d2b5"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "987d496a-94d6-4fad-afcb-7781cb55197e", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("6298d724-1c4d-4c0d-91c0-1d6f21853f8f"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "651a1e97-54b6-4c04-b418-95e6a0d59ca1", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "Petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("36551419-12fc-4010-8dd5-4371698cf536"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "019fc32c-3313-4f8d-bce7-1c187474353f", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "Ivanov@gmail.com", null, "33333333", "52" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("12561c57-8647-47a4-bded-3e3c8345d2b5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("36551419-12fc-4010-8dd5-4371698cf536"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("6298d724-1c4d-4c0d-91c0-1d6f21853f8f"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "047dad6b-e249-4a49-8f81-c383bc361422");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "f18487c4-0f3d-4ef8-b6db-9d0f183c92b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "ee23e3d9-9176-42b9-b475-06b5c6d9bb83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "53414803-d4c6-4e22-8039-dd484113f83d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("d0a5c2b9-7df8-4f61-818a-308e2831de3d"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "8f29d328-3317-4d00-8145-ff5f192f0f3c", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "pupkin@gmail.com", null, "11111111", "19" },
                    { new Guid("df156296-847a-4edb-8dc6-b7fe5cb7f55a"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "77cb35d9-1254-4d1b-9d21-b1fc762c96d7", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "Petrov@gmail.com", null, "22222222", "31" },
                    { new Guid("da74cd00-c6ee-4ab6-9dee-719ec11f3648"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "c73c6cdc-fb66-43bd-94f2-97c0932bf22c", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "Ivanov@gmail.com", null, "33333333", "52" }
                });
        }
    }
}
