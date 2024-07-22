using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class CityConfiguration: _BaseConfiguration<CityInfo>
    {
        public override void Configure(EntityTypeBuilder<CityInfo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CityName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Lat)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(c => c.Lng)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Population)
                .IsRequired();

            base.Configure(builder);
        }
    }
}