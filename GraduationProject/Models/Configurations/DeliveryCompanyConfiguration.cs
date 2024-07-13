using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class DeliveryCompanyConfiguration : _BaseConfiguration<DeliveryCompany>
    {
        public override void Configure(EntityTypeBuilder<DeliveryCompany> builder)
        {
            base.Configure(builder);

            builder.Property(dc => dc.Name).IsRequired().HasMaxLength(100);
            builder.Property(dc => dc.ContactNumber).HasMaxLength(20);
            builder.Property(dc => dc.Email).HasMaxLength(100);
            builder.Property(dc => dc.Address).HasMaxLength(255);
            builder.Property(dc => dc.RowGuid).IsRequired();
            builder.Property(dc => dc.CreatedAtUtc).IsRequired();
        }
    }
}
