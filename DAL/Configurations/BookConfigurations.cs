using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    internal class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.BookId).IsRequired();
            builder.Property(p => p.FilePath).IsRequired().HasMaxLength(100);
            builder.Property(p => p.BookName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.YearOfPublishing).IsRequired().HasMaxLength(10);
            builder.Property(p => p.PublisherId).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Rating).IsRequired();
            builder.Property(p => p.FileType).IsRequired();
            builder.HasKey(k => k.BookId);
            builder.HasOne(o => o.Publisher).WithMany(m => m.Books).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Author).WithMany(m => m.Books).OnDelete(DeleteBehavior.Cascade);

        }
    }
}