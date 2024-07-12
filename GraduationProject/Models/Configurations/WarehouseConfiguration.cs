using GraduationProject.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace GraduationProject.Models.Configurations
{
    public class WarehouseConfiguration : _BaseConfiguration<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
            builder.Property(c => c.PhoneNumber).HasMaxLength(255);
        }
    }
}