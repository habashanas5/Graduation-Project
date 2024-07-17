using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class PurchaseOrderItemConfiguration : _BaseConfiguration<ManufacturingOrdersItems>
    {
        public override void Configure(EntityTypeBuilder<ManufacturingOrdersItems> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.PurchaseOrderId).IsRequired();
            builder.Property(c => c.ProductId).IsRequired();
            builder.Property(c => c.Summary).HasMaxLength(100);
        }
    }
}