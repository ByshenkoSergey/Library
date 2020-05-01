using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("3e4a92b0-440c-4337-813e-a0f3dd2bf53a"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "4751fc89-e387-4cf6-8216-21c845c15db7", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" },
                    { new Guid("71cb26a1-e65c-4d43-9f66-cda33056f232"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "3eced11b-5e26-4b85-b979-ad208ac52314", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("37185335-bab6-4d2f-b7b4-8a454327dc21"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("4d0b7f16-8ea1-4d62-a63a-02fec3a8e0aa"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("85691dc6-7a56-49c9-b310-998acab7f9f4"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("94c6f173-72ed-4e9a-89f5-d61a611de2dd"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("b41d9e9b-80ee-4fa5-bc26-1098847f622f"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("cf6413aa-a908-4ce0-a0fe-4afb4ac0d594"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e2134267-1183-42fe-be17-0f7e38973b00"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("f13b3ba0-52eb-474e-b9f1-cd6857771d98"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fb599382-3096-4f33-bc61-c18eefb9950f"),
                column: "AuthorBiography",
                value: "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"),
                column: "PublisherInfo",
                value: "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"),
                column: "PublisherInfo",
                value: "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"),
                column: "PublisherInfo",
                value: "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"),
                column: "PublisherInfo",
                value: "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("e4ddab7d-5b54-4683-9f0d-a3bc50bceee3"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "c31047cb-dd58-4a84-b7e6-3631a181f200", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "ivanov@gmail.com", null, "33333333", "52" },
                    { new Guid("52da52e2-d1a4-49d8-ac5d-ff6205c0daec"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "110c49ea-27be-4d64-89b0-2acbd1dd8855", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "petrov@gmail.com", null, "22222222", "31" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("37185335-bab6-4d2f-b7b4-8a454327dc21"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("4d0b7f16-8ea1-4d62-a63a-02fec3a8e0aa"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("85691dc6-7a56-49c9-b310-998acab7f9f4"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("94c6f173-72ed-4e9a-89f5-d61a611de2dd"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("b41d9e9b-80ee-4fa5-bc26-1098847f622f"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("cf6413aa-a908-4ce0-a0fe-4afb4ac0d594"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e2134267-1183-42fe-be17-0f7e38973b00"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("f13b3ba0-52eb-474e-b9f1-cd6857771d98"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fb599382-3096-4f33-bc61-c18eefb9950f"),
                column: "AuthorBiography",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"),
                column: "PublisherInfo",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"),
                column: "PublisherInfo",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"),
                column: "PublisherInfo",
                value: "...Text...");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"),
                column: "PublisherInfo",
                value: "...Text...");
        }
    }
}
