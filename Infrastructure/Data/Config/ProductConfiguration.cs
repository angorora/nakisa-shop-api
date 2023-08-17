﻿using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
	public class ProductConfiguration: IEntityTypeConfiguration<Product>
	{
		public ProductConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");
            builder.Property(p => p.ImgUrl).IsRequired();
            builder.HasOne(p => p.ProductBrands).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(p => p.ProductTypes).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}
