using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    internal class PublishingHousesConfigurations : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasKey(k => k.PublishingHouseId);
            builder.Property(p => p.PublishingHouseName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PublishingHouseEmail).HasMaxLength(35);
            builder.Property(p => p.PublishingHouseTellNumber).HasMaxLength(25);
            builder.Property(p => p.PublishingHouseInfo).HasMaxLength(200);
            
        }
    }
}