using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    internal class PublisherConfigurations : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(k => k.PublisherId);
            builder.Property(p => p.PublisherName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PublisherEmail).HasMaxLength(35);
            builder.Property(p => p.PublisherTellNumber).HasMaxLength(25);
            builder.Property(p => p.PublisherInfo).HasMaxLength(200);
            
        }
    }
}