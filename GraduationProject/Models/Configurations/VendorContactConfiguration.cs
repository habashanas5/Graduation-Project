using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class VendorContactConfiguration : _BaseConfiguration<FactoriesContacts>
    {
        public override void Configure(EntityTypeBuilder<FactoriesContacts> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.FactorysId).IsRequired();
            builder.Property(c => c.Number).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.EmailAddress).HasMaxLength(100);
        }
    }
}