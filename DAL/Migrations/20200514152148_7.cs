using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "d8e20760-58ab-49ba-ad21-b5089410fa5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("12359876-5423-1564-8957-8215647acdfa"),
                column: "ConcurrencyStamp",
                value: "7c496c8a-4309-4508-b10a-5d12a129be56");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a7548337-8541-515f-f961-a25489212a32"),
                column: "ConcurrencyStamp",
                value: "9d09626b-477a-456f-b372-5426d5ecc146");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                column: "ConcurrencyStamp",
                value: "c33afa2f-735d-46e4-8125-97533ce46a9a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("2816e007-940d-4240-8332-d04b188ea0e8"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "d84d19e1-1758-44c2-8e3a-e2c9bc5e9364", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "admin", null, "admin", "19" },
                    { new Guid("d23d29eb-a10b-4f5c-b0da-c746dda16d8f"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "3d2d19b0-7102-4d04-85c5-731dfbe6d247", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "moderator", null, "moderator", "31" },
                    { new Guid("cdb47b50-8ec5-4e25-b6e8-a9b2951f17ea"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "172a9b4b-4bd5-4c19-9a2e-96aaf143c46f", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "user", null, "user", "52" },
                    { new Guid("80c83355-360e-48c8-bcb0-352ac39d9d93"), 0, new Guid("a7548337-8541-515f-f961-a25489212a32"), "639592f6-6f0c-4445-83e9-291875adb64d", "sidorov@gmail.com", false, false, null, null, null, null, "095-989-12-12", false, null, false, "Andrey", "Sidorov", "superuser", null, "superuser", "52" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"),
                column: "BookName",
                value: "Нello cat.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                column: "BookName",
                value: "Black sea.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                column: "BookName",
                value: "Square World.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                column: "BookName",
                value: "Happy bird.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                column: "BookName",
                value: "Black dog.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                column: "BookName",
                value: "New spring.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                column: "BookName",
                value: "Merry.txt");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                column: "BookName",
                value: "Little snake.txt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("2816e007-940d-4240-8332-d04b188ea0e8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("80c83355-360e-48c8-bcb0-352ac39d9d93"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("cdb47b50-8ec5-4e25-b6e8-a9b2951f17ea"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: new Guid("d23d29eb-a10b-4f5c-b0da-c746dda16d8f"));

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
                column: "BookName",
                value: "Нello cat");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                column: "BookName",
                value: "Black sea");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                column: "BookName",
                value: "Square World");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                column: "BookName",
                value: "Happy bird");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                column: "BookName",
                value: "Black dog");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                column: "BookName",
                value: "New spring");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                column: "BookName",
                value: "Merry");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                column: "BookName",
                value: "Little snake");
        }
    }
}
