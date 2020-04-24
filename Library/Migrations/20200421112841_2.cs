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
                keyValue: new Guid("31d3c0d3-088b-4b95-868e-6176c2e993a5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("e311c437-4f04-4854-bbe2-8412346bf285"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("e8729740-dd8d-4100-b1a5-1ac5db6ab584"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "8da1d239-128e-4e03-a840-1a89f0c0b2f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "f2116151-fd5c-43e4-acc8-61d5faa32069");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "74dcd55d-8253-4839-974c-f92794d5e873");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "RoleId", "ConcurrencyStamp", "Id", "Name", "NormalizedName", "RoleName" },
                values: new object[] { new Guid("a7548337-8541-515f-f961-a25489212a32"), "0bfdf3f1-f591-466b-b14a-4d64bc16231c", new Guid("00000000-0000-0000-0000-000000000000"), null, null, "SuperUser" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("c7a480cc-327a-45c2-8fb4-db77aee70cf5"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "094d6b96-29a3-417b-9a7d-9712ddbf5104", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "Pupkin@gmail.com", null, "1111", "19" },
                    { new Guid("657bf850-9f8f-44c8-8057-b152c4aaa15e"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "8f6c7d63-ceb1-455d-8632-dbd42c563419", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "Petrov@gmail.com", null, "2222", "31" },
                    { new Guid("b2be8bd2-bcf3-4749-9788-f92170689b74"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "91a5f5d8-4ea2-4114-9355-cc270c8bdd51", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "Ivanov@gmail.com", null, "3333", "52" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("657bf850-9f8f-44c8-8057-b152c4aaa15e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("b2be8bd2-bcf3-4749-9788-f92170689b74"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("c7a480cc-327a-45c2-8fb4-db77aee70cf5"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12354898-7456-3215-4895-123654879878"),
                column: "ConcurrencyStamp",
                value: "e7d83dc4-256b-486b-892e-3b6b854b8e0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "af35f927-cd53-4de8-a5a1-af44a8429f2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "a8e05484-7264-4826-9d05-018a40912418");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("e311c437-4f04-4854-bbe2-8412346bf285"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "6461fd70-e0bf-4ad2-ac4b-b264a9c714ac", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "Pupkin@gmail.com", null, "1111", "19" },
                    { new Guid("31d3c0d3-088b-4b95-868e-6176c2e993a5"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "60a98f58-ba88-4e95-88dc-0963a99cf1ea", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "Petrov@gmail.com", null, "2222", "31" },
                    { new Guid("e8729740-dd8d-4100-b1a5-1ac5db6ab584"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "54851a06-9f04-472f-9056-98d7cb975b34", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "Ivanov@gmail.com", null, "3333", "52" }
                });
        }
    }
}
