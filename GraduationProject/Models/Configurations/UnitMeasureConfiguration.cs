﻿using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Models.Configurations
{
    public class UnitMeasureConfiguration : _BaseConfiguration<UnitMeasure>
    {
        public override void Configure(EntityTypeBuilder<UnitMeasure> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);


        }
    }
}