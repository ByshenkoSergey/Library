using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BookFileAddress",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "PublisherInfo",
                table: "Publishers",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Books",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Books",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorBiography",
                table: "Authors",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Нello cat.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Black sea.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Square World.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Happy bird.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Black dog.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/New spring.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Merry.txt", "application/octet-stream" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                columns: new[] { "FilePath", "FileType" },
                values: new object[] { "BookLibrary/Little snake.txt", "application/octet-stream" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "PublisherInfo",
                table: "Publishers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookFileAddress",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorBiography",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"),
                column: "BookFileAddress",
                value: "BookLibrary/Нello cat.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                column: "BookFileAddress",
                value: "BookLibrary/Black sea.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                column: "BookFileAddress",
                value: "BookLibrary/Square World.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                column: "BookFileAddress",
                value: "BookLibrary/Happy bird.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                column: "BookFileAddress",
                value: "BookLibrary/Black dog.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                column: "BookFileAddress",
                value: "BookLibrary/New spring.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                column: "BookFileAddress",
                value: "BookLibrary/Merry.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                column: "BookFileAddress",
                value: "BookLibrary/Little snake.txt");
        }
    }
}
