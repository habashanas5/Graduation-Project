using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class SalesSummaryByDaysConfiguration : _BaseConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<SalesSummaryByDay> builder)
        {
            builder.HasKey(ssb => ssb.Id);
            builder.Property(ssb => ssb.Date).IsRequired();
            builder.Property(ssb => ssb.ProductId).IsRequired();
            builder.Property(ssb => ssb.ProductName).IsRequired().HasMaxLength(255);
            builder.Property(ssb => ssb.NumberOfSales).IsRequired();
            builder.Property(ssb => ssb.NumberOfProductSold).IsRequired();
            builder.Property(ssb => ssb.RowGuid).IsRequired();
            builder.Property(ssb => ssb.CreatedByUserId).IsRequired(false);
            builder.Property(ssb => ssb.CreatedAtUtc).IsRequired();
            builder.Property(ssb => ssb.UpdatedByUserId).IsRequired(false);
            builder.Property(ssb => ssb.UpdatedAtUtc).IsRequired();
            builder.Property(ssb => ssb.IsNotDeleted).IsRequired();

        }
    }
}
