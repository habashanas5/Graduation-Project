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

            builder.Property(c => c.CityAscii)
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

            builder.Property(c => c.Iso2)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(c => c.Iso3)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(c => c.AdminName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(c => c.Capital)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(c => c.Population)
                .IsRequired();

            base.Configure(builder);
        }
    }
}