﻿using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class AdjustmentPlusConfiguration : _BaseConfiguration<AdjustmentPlus>
    {
        public override void Configure(EntityTypeBuilder<AdjustmentPlus> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Number).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
        }
    }
}