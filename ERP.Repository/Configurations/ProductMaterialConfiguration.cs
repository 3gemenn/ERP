using ERP.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Configurations
{
    public class ProductMaterialConfiguration : IEntityTypeConfiguration<ProductMaterial>
    {
        public void Configure(EntityTypeBuilder<ProductMaterial> builder)
        {
            // Define the table name
            builder.ToTable("ProductMaterials");

            // Define the primary key
            builder.HasKey(pm => pm.Id);

            // Define properties
            builder.Property(pm => pm.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pm => pm.ProductId)
                .IsRequired();

            builder.Property(pm => pm.MaterialId)
                .IsRequired();

            builder.Property(pm => pm.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Define relationships
            builder.HasOne(pm => pm.Product)
                .WithMany(p => p.ProductMaterials)
                .HasForeignKey(pm => pm.ProductId);

            builder.HasOne(pm => pm.Material)
                .WithMany(m => m.ProductMaterials)
                .HasForeignKey(pm => pm.MaterialId);

            // Additional configurations if needed
        }
    }

}
