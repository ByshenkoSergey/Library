using DAL.Models.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    internal class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(k => k.RoleId);
            builder.Ignore(i => i.Id);
            builder.HasMany(m => m.ApplicationUsers).WithOne(o => o.ApplicationUserRole).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Property(p => p.RoleName).HasMaxLength(256);
            builder.Property(p => p.Id).ValueGeneratedNever();
        }
    }
}