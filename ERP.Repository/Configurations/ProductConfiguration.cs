using ERP.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Define the table name
            builder.ToTable("Products");

            // Define the primary key
            builder.HasKey(p => p.Id);

            // Define properties
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(255);

            builder.Property(p => p.UnitePrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            // Define relationships
            builder.HasMany(p => p.WorkOrders)
                .WithOne(wo => wo.Product)
                .HasForeignKey(wo => wo.ProductId);

            builder.HasMany(p => p.ProductMaterials)
                .WithOne(pm => pm.Product)
                .HasForeignKey(pm => pm.ProductId);

            // Additional configurations if needed
        }
    }
}
