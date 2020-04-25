using DAL.Configurations;
using DAL.FailData;
using DAL.Models;
using DAL.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DAL.Context
{
    public class LibraryDataBaseContext : IdentityDbContext<User, UserRole, Guid>
    {
        public LibraryDataBaseContext(DbContextOptions<LibraryDataBaseContext> options)
: base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Book>().HasData(BooksData.GetBooksData());
            modelBuilder.Entity<Author>().HasData(AuthorsData.GetAuthorsData());
            modelBuilder.Entity<PublishingHouse>().HasData(PublishingHousesData.GetPublishingHousesData());
            modelBuilder.Entity<UserRole>().HasData(ApplicationUserRoleData.GetApplicationUserRoleData());
            modelBuilder.Entity<User>().HasData(ApplicationUserData.GetApplicationUserData());
        }
    }
}
