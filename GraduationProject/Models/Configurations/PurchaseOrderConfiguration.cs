using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class PurchaseOrderConfiguration : _BaseConfiguration<ManufacturingOrdersTable>
    {
        public override void Configure(EntityTypeBuilder<ManufacturingOrdersTable> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.VendorId).IsRequired();
            builder.Property(c => c.TaxId).IsRequired();
            builder.Property(c => c.Number).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
        }
    }
}