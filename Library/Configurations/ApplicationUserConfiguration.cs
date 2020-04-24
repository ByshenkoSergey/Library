using DAL.Models.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(k => k.UserId);
            builder.Ignore(i => i.Id);
            builder.HasOne(o => o.ApplicationUserRole).WithMany(m => m.ApplicationUsers).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Property(p => p.ApplicationUserRoleId).ValueGeneratedNever();
            builder.Property(p => p.UserLogin).HasMaxLength(256);
            builder.Property(p => p.UserPassword).HasMaxLength(256);
            builder.Property(p => p.UserFirstName).HasMaxLength(256);
            builder.Property(p => p.UserLastName).HasMaxLength(256);
            builder.Property(p => p.PhoneNumber).HasMaxLength(256);
            builder.Property(p => p.Email).HasMaxLength(256);
            builder.Property(p => p.UserYearsOld).HasMaxLength(25);

        }
    }
}