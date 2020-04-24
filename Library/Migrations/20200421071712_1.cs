using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(maxLength: 50, nullable: false),
                    AuthorBiography = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouses",
                columns: table => new
                {
                    PublishingHouseId = table.Column<Guid>(nullable: false),
                    PublishingHouseName = table.Column<string>(maxLength: 50, nullable: false),
                    PublishingHouseInfo = table.Column<string>(maxLength: 200, nullable: true),
                    PublishingHouseTellNamber = table.Column<string>(maxLength: 25, nullable: true),
                    PublishingHouseEmail = table.Column<string>(maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouses", x => x.PublishingHouseId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserLogin = table.Column<string>(maxLength: 256, nullable: true),
                    UserPassword = table.Column<string>(maxLength: 256, nullable: true),
                    UserFirstName = table.Column<string>(maxLength: 256, nullable: true),
                    UserLastName = table.Column<string>(maxLength: 256, nullable: true),
                    UserYearsOld = table.Column<string>(maxLength: 25, nullable: true),
                    ApplicationUserRoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_ApplicationUserRoleId",
                        column: x => x.ApplicationUserRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    BookName = table.Column<string>(maxLength: 50, nullable: false),
                    BookFileAddress = table.Column<string>(maxLength: 100, nullable: false),
                    YearOfPublishing = table.Column<string>(maxLength: 10, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    PublishingHouseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_PublishingHouses_PublishingHouseId",
                        column: x => x.PublishingHouseId,
                        principalTable: "PublishingHouses",
                        principalColumn: "PublishingHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "RoleId", "ConcurrencyStamp", "Id", "Name", "NormalizedName", "RoleName" },
                values: new object[,]
                {
                    { new Guid("12354898-7456-3215-4895-123654879878"), "e7d83dc4-256b-486b-892e-3b6b854b8e0a", new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Admin" },
                    { new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "a8e05484-7264-4826-9d05-018a40912418", new Guid("00000000-0000-0000-0000-000000000000"), null, null, "User" },
                    { new Guid("12359876-5423-1564-8957-8215647acdfa"), "af35f927-cd53-4de8-a5a1-af44a8429f2e", new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorBiography", "AuthorName" },
                values: new object[,]
                {
                    { new Guid("94c6f173-72ed-4e9a-89f5-d61a611de2dd"), "...Text...", "Semenov A.P." },
                    { new Guid("b41d9e9b-80ee-4fa5-bc26-1098847f622f"), "...Text...", "Fedorov Y.I." },
                    { new Guid("4d0b7f16-8ea1-4d62-a63a-02fec3a8e0aa"), "...Text...", "Ivanov I.P." },
                    { new Guid("37185335-bab6-4d2f-b7b4-8a454327dc21"), "...Text...", "Sidorov S.A." },
                    { new Guid("f13b3ba0-52eb-474e-b9f1-cd6857771d98"), "...Text...", "Logkin A.Z." },
                    { new Guid("85691dc6-7a56-49c9-b310-998acab7f9f4"), "...Text...", "Vilkin V.A." },
                    { new Guid("e2134267-1183-42fe-be17-0f7e38973b00"), "...Text...", "Petrov P.P." },
                    { new Guid("fb599382-3096-4f33-bc61-c18eefb9950f"), "...Text...", "Smirnov A.A." },
                    { new Guid("cf6413aa-a908-4ce0-a0fe-4afb4ac0d594"), "...Text...", "Pavlov P.A." }
                });

            migrationBuilder.InsertData(
                table: "PublishingHouses",
                columns: new[] { "PublishingHouseId", "PublishingHouseEmail", "PublishingHouseInfo", "PublishingHouseName", "PublishingHouseTellNamber" },
                values: new object[,]
                {
                    { new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"), "NewWord@gmail.com", "...Text...", "New word", "+38 (095) 111-11-11" },
                    { new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"), "PenPen@gmail.com", "...Text...", "Pen and pensile", "+38 (095) 222-22-22" },
                    { new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"), "absde@gmail.com", "...Text...", "ABSDE", "+38 (095) 333-33-33" },
                    { new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"), "hbooks@gmail.com", "...Text...", "Hape books", "+38 (095) 999-99-99" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ApplicationUserRoleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserLogin", "UserName", "UserPassword", "UserYearsOld" },
                values: new object[,]
                {
                    { new Guid("e311c437-4f04-4854-bbe2-8412346bf285"), 0, new Guid("12354898-7456-3215-4895-123654879878"), "6461fd70-e0bf-4ad2-ac4b-b264a9c714ac", "pupkin@gmail.com", false, false, null, null, null, null, "095-987-35-67", false, null, false, "Vova", "Pupkin", "Pupkin@gmail.com", null, "1111", "19" },
                    { new Guid("e8729740-dd8d-4100-b1a5-1ac5db6ab584"), 0, new Guid("a75489d7-8542-315f-f961-a254892c8a32"), "54851a06-9f04-472f-9056-98d7cb975b34", "ivanov@gmail.com", false, false, null, null, null, null, "095-989-11-11", false, null, false, "Taras", "Ivanov", "Ivanov@gmail.com", null, "3333", "52" },
                    { new Guid("31d3c0d3-088b-4b95-868e-6176c2e993a5"), 0, new Guid("12359876-5423-1564-8957-8215647acdfa"), "60a98f58-ba88-4e95-88dc-0963a99cf1ea", "petrov@gmail.com", false, false, null, null, null, null, "095-987-00-12", false, null, false, "Sergey", "Petrov", "Petrov@gmail.com", null, "2222", "31" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "BookFileAddress", "BookName", "PublishingHouseId", "Rating", "YearOfPublishing" },
                values: new object[,]
                {
                    { new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"), new Guid("37185335-bab6-4d2f-b7b4-8a454327dc21"), "BookLibrary/Happy bird.txt", "Happy bird", new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"), 2, "1994" },
                    { new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"), new Guid("85691dc6-7a56-49c9-b310-998acab7f9f4"), "BookLibrary/Merry.txt", "Merry", new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"), 4, "2012" },
                    { new Guid("0201e414-a277-44b3-a673-34d59d722c5e"), new Guid("94c6f173-72ed-4e9a-89f5-d61a611de2dd"), "BookLibrary/Black sea.txt", "Black sea", new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"), 3, "2008" },
                    { new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"), new Guid("fb599382-3096-4f33-bc61-c18eefb9950f"), "BookLibrary/Square World.txt", "Square World", new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"), 5, "2015" },
                    { new Guid("93345979-d3c9-4255-90ef-541a8f937a73"), new Guid("4d0b7f16-8ea1-4d62-a63a-02fec3a8e0aa"), "BookLibrary/Black dog.txt", "Black dog", new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"), 0, "2001" },
                    { new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"), new Guid("f13b3ba0-52eb-474e-b9f1-cd6857771d98"), "BookLibrary/Little snake.txt", "Little snake", new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"), 5, "2009" },
                    { new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"), new Guid("b41d9e9b-80ee-4fa5-bc26-1098847f622f"), "BookLibrary/Нello cat.txt", "Нello cat", new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"), 5, "2010" },
                    { new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"), new Guid("e2134267-1183-42fe-be17-0f7e38973b00"), "BookLibrary/New spring.txt", "New spring", new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"), 4, "2005" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserRoleId",
                table: "AspNetUsers",
                column: "ApplicationUserRoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "PublishingHouses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
