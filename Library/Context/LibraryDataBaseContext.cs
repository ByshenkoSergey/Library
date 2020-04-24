using DAL.Configurations;
using DAL.FailData;
using DAL.Models;
using DAL.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Context
{
    public class LibraryDataBaseContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
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

            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new PublishingHousesConfigurations());
            modelBuilder.ApplyConfiguration(new AuthorConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());

            modelBuilder.Entity<Book>().HasData(BooksData.GetBooksData());
            modelBuilder.Entity<Author>().HasData(AuthorsData.GetAuthorsData());
            modelBuilder.Entity<PublishingHouse>().HasData(PublishingHousesData.GetPublishingHousesData());
            modelBuilder.Entity<ApplicationUserRole>().HasData(ApplicationUserRoleData.GetApplicationUserRoleData());
            modelBuilder.Entity<ApplicationUser>().HasData(ApplicationUserData.GetApplicationUserData());

        }

    }
}
