using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class VendorConfiguration : _BaseConfiguration<Factorys>
    {
        public override void Configure(EntityTypeBuilder<Factorys> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.VendorGroupId).IsRequired();
            builder.Property(c => c.VendorCategoryId).IsRequired();
            builder.Property(c => c.Number).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
            builder.Property(c => c.Street).HasMaxLength(100);
            builder.Property(c => c.City).HasMaxLength(100);
            builder.Property(c => c.State).HasMaxLength(100);
            builder.Property(c => c.ZipCode).HasMaxLength(100);
            builder.Property(c => c.Country).HasMaxLength(100);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.FaxNumber).HasMaxLength(20);
            builder.Property(c => c.EmailAddress).HasMaxLength(100);
            builder.Property(c => c.Website).HasMaxLength(100);
        }
    }
}