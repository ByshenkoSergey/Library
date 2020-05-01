﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(LibraryDataBaseContext))]
    [Migration("20200501085424_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorBiography")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("94c6f173-72ed-4e9a-89f5-d61a611de2dd"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Semenov A.P."
                        },
                        new
                        {
                            AuthorId = new Guid("b41d9e9b-80ee-4fa5-bc26-1098847f622f"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Fedorov Y.I."
                        },
                        new
                        {
                            AuthorId = new Guid("4d0b7f16-8ea1-4d62-a63a-02fec3a8e0aa"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Ivanov I.P."
                        },
                        new
                        {
                            AuthorId = new Guid("37185335-bab6-4d2f-b7b4-8a454327dc21"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Sidorov S.A."
                        },
                        new
                        {
                            AuthorId = new Guid("f13b3ba0-52eb-474e-b9f1-cd6857771d98"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Logkin A.Z."
                        },
                        new
                        {
                            AuthorId = new Guid("85691dc6-7a56-49c9-b310-998acab7f9f4"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Vilkin V.A."
                        },
                        new
                        {
                            AuthorId = new Guid("e2134267-1183-42fe-be17-0f7e38973b00"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Petrov P.P."
                        },
                        new
                        {
                            AuthorId = new Guid("fb599382-3096-4f33-bc61-c18eefb9950f"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Smirnov A.A."
                        },
                        new
                        {
                            AuthorId = new Guid("cf6413aa-a908-4ce0-a0fe-4afb4ac0d594"),
                            AuthorBiography = "Mauris viverra a mauris at fringilla.Ut quis elit non libero pretium sollicitudin a et dolor.Duis euismod volutpat eros sed facilisis.Nam lorem dui,ultricies vitae luctus aliquamvolutpat vel nisl.In hac habitasse platea dictumst.Pellentesque cursus placerat nisi et condimentum.Etiam eget nisl elementum,egestas justo vel,iaculis ex.Fusce pulvinar feugiat orci, ac ultricies est ultrices in. Donec blandit maximus tempor.Praesent a hendrerit lectus.Donec ex libero,tempor nec purus vitae, bibendum elementum metus.Phasellus mollis justo et iaculis aliquam.Aenean vitae bibendum enim.Quisque sagittis volutpat mattis.Integer viverra nec dolor vitae malesuada.",
                            AuthorName = "Pavlov P.A."
                        });
                });

            modelBuilder.Entity("DAL.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookFileAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("YearOfPublishing")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("0201e414-a277-44b3-a673-34d59d722c5e"),
                            AuthorId = new Guid("94c6f173-72ed-4e9a-89f5-d61a611de2dd"),
                            BookFileAddress = "BookLibrary/Black sea.txt",
                            BookName = "Black sea",
                            PublisherId = new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"),
                            Rating = 3,
                            YearOfPublishing = "2008"
                        },
                        new
                        {
                            BookId = new Guid("0183e953-f44f-42c0-8cca-b0475b1f2218"),
                            AuthorId = new Guid("b41d9e9b-80ee-4fa5-bc26-1098847f622f"),
                            BookFileAddress = "BookLibrary/Нello cat.txt",
                            BookName = "Нello cat",
                            PublisherId = new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"),
                            Rating = 5,
                            YearOfPublishing = "2010"
                        },
                        new
                        {
                            BookId = new Guid("93345979-d3c9-4255-90ef-541a8f937a73"),
                            AuthorId = new Guid("4d0b7f16-8ea1-4d62-a63a-02fec3a8e0aa"),
                            BookFileAddress = "BookLibrary/Black dog.txt",
                            BookName = "Black dog",
                            PublisherId = new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"),
                            Rating = 0,
                            YearOfPublishing = "2001"
                        },
                        new
                        {
                            BookId = new Guid("57c42200-905e-44cf-982f-7a70fb8d04ff"),
                            AuthorId = new Guid("37185335-bab6-4d2f-b7b4-8a454327dc21"),
                            BookFileAddress = "BookLibrary/Happy bird.txt",
                            BookName = "Happy bird",
                            PublisherId = new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"),
                            Rating = 2,
                            YearOfPublishing = "1994"
                        },
                        new
                        {
                            BookId = new Guid("fd5dd762-8765-412b-83a7-c02a27ed858a"),
                            AuthorId = new Guid("f13b3ba0-52eb-474e-b9f1-cd6857771d98"),
                            BookFileAddress = "BookLibrary/Little snake.txt",
                            BookName = "Little snake",
                            PublisherId = new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"),
                            Rating = 5,
                            YearOfPublishing = "2009"
                        },
                        new
                        {
                            BookId = new Guid("dd095794-2af3-4845-b2ee-51ab0c151e2c"),
                            AuthorId = new Guid("85691dc6-7a56-49c9-b310-998acab7f9f4"),
                            BookFileAddress = "BookLibrary/Merry.txt",
                            BookName = "Merry",
                            PublisherId = new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"),
                            Rating = 4,
                            YearOfPublishing = "2012"
                        },
                        new
                        {
                            BookId = new Guid("b9c9bcfc-2c37-4718-8e16-978f06359f43"),
                            AuthorId = new Guid("e2134267-1183-42fe-be17-0f7e38973b00"),
                            BookFileAddress = "BookLibrary/New spring.txt",
                            BookName = "New spring",
                            PublisherId = new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"),
                            Rating = 4,
                            YearOfPublishing = "2005"
                        },
                        new
                        {
                            BookId = new Guid("166fd39a-0f80-4efd-80bf-d7907492222b"),
                            AuthorId = new Guid("fb599382-3096-4f33-bc61-c18eefb9950f"),
                            BookFileAddress = "BookLibrary/Square World.txt",
                            BookName = "Square World",
                            PublisherId = new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"),
                            Rating = 5,
                            YearOfPublishing = "2015"
                        });
                });

            modelBuilder.Entity("DAL.Models.IdentityModels.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ApplicationUserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserLogin")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserYearsOld")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("UserId");

                    b.HasIndex("ApplicationUserRoleId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e5dbc6e3-e4f0-436c-9e9e-b9e4237cbb61"),
                            AccessFailedCount = 0,
                            ApplicationUserRoleId = new Guid("12354898-7456-3215-4895-123654879878"),
                            ConcurrencyStamp = "079b859b-4044-46b6-b795-cdaf72b85315",
                            Email = "pupkin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "095-987-35-67",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserFirstName = "Vova",
                            UserLastName = "Pupkin",
                            UserLogin = "pupkin@gmail.com",
                            UserPassword = "11111111",
                            UserYearsOld = "19"
                        },
                        new
                        {
                            UserId = new Guid("71cb26a1-e65c-4d43-9f66-cda33056f232"),
                            AccessFailedCount = 0,
                            ApplicationUserRoleId = new Guid("12359876-5423-1564-8957-8215647acdfa"),
                            ConcurrencyStamp = "3eced11b-5e26-4b85-b979-ad208ac52314",
                            Email = "petrov@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "095-987-00-12",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserFirstName = "Sergey",
                            UserLastName = "Petrov",
                            UserLogin = "petrov@gmail.com",
                            UserPassword = "22222222",
                            UserYearsOld = "31"
                        },
                        new
                        {
                            UserId = new Guid("3e4a92b0-440c-4337-813e-a0f3dd2bf53a"),
                            AccessFailedCount = 0,
                            ApplicationUserRoleId = new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                            ConcurrencyStamp = "4751fc89-e387-4cf6-8216-21c845c15db7",
                            Email = "ivanov@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "095-989-11-11",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserFirstName = "Taras",
                            UserLastName = "Ivanov",
                            UserLogin = "ivanov@gmail.com",
                            UserPassword = "33333333",
                            UserYearsOld = "52"
                        });
                });

            modelBuilder.Entity("DAL.Models.IdentityModels.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("RoleId");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("12354898-7456-3215-4895-123654879878"),
                            ConcurrencyStamp = "19b4110e-bf1a-477b-8cb2-7a3c3bbc7dcd",
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = new Guid("a75489d7-8542-315f-f961-a254892c8a32"),
                            ConcurrencyStamp = "7924cca0-28aa-4c99-afd1-570a702206ce",
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = new Guid("a7548337-8541-515f-f961-a25489212a32"),
                            ConcurrencyStamp = "5f5cd6e7-25bd-46dc-a334-13ce62fd5b4b",
                            RoleName = "SuperUser"
                        },
                        new
                        {
                            RoleId = new Guid("12359876-5423-1564-8957-8215647acdfa"),
                            ConcurrencyStamp = "b76dd0a8-7317-47e2-b54c-56a026e8a199",
                            RoleName = "Moderator"
                        });
                });

            modelBuilder.Entity("DAL.Models.Publisher", b =>
                {
                    b.Property<Guid>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PublisherEmail")
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("PublisherInfo")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PublisherTellNumber")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherId = new Guid("e40037b1-36b2-4671-bd1d-f0784e1299bf"),
                            PublisherEmail = "NewWord@gmail.com",
                            PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.",
                            PublisherName = "New word",
                            PublisherTellNumber = "+38 (095) 111-11-11"
                        },
                        new
                        {
                            PublisherId = new Guid("e1ad8ea8-6019-4250-893d-41372a755c05"),
                            PublisherEmail = "PenPen@gmail.com",
                            PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.",
                            PublisherName = "Pen and pensile",
                            PublisherTellNumber = "+38 (095) 222-22-22"
                        },
                        new
                        {
                            PublisherId = new Guid("5a8f4495-ac8f-4ecc-beb2-58409180073b"),
                            PublisherEmail = "absde@gmail.com",
                            PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.",
                            PublisherName = "ABSDE",
                            PublisherTellNumber = "+38 (095) 333-33-33"
                        },
                        new
                        {
                            PublisherId = new Guid("35b6fdea-c2aa-4edf-af6e-655aa1eb06a5"),
                            PublisherEmail = "hbooks@gmail.com",
                            PublisherInfo = "Fusce eget eros pretium, dictum tellus eu, luctus nulla. Cras lacinia facilisis tortor, eleifend condimentum metus facilisis quis.+Nullam libero ipsum, pretium nec volutpat eget, ultrices non velit. Sed nisi lectus, fermentum et elit at, mollis interdum purus. Nullam orci elit,posuere non suscipit eget, fringilla ac diam. Praesent cursus, leo ut lacinia cursus, ipsum est tempor odio, ac laoreet ex metus non massa. Duis imperdiet quis erat vel bibendum.",
                            PublisherName = "Hape books",
                            PublisherTellNumber = "+38 (095) 999-99-99"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DAL.Models.Book", b =>
                {
                    b.HasOne("DAL.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.IdentityModels.User", b =>
                {
                    b.HasOne("DAL.Models.IdentityModels.UserRole", "ApplicationUserRole")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ApplicationUserRoleId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("DAL.Models.IdentityModels.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DAL.Models.IdentityModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DAL.Models.IdentityModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("DAL.Models.IdentityModels.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.IdentityModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DAL.Models.IdentityModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
