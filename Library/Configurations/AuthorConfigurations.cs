using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    internal class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(k => k.AuthorId);
            builder.Property(p => p.AuthorName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.AuthorBiography).HasMaxLength(100);
            builder.HasMany(o => o.Books).WithOne(m => m.Author).OnDelete(DeleteBehavior.Cascade);
        }
    }
}