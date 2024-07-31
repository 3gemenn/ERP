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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        

        public void Configure(EntityTypeBuilder<Material> builder)
        {
            // Define the table name
            builder.ToTable("Materials");

            // Define the primary key
            builder.HasKey(m => m.Id);

            // Define properties
            builder.Property(m => m.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(500);

            builder.Property(m => m.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // Define relationships
            builder.HasMany(m => m.ProductMaterials)
                .WithOne(pm => pm.Material)
                .HasForeignKey(pm => pm.MaterialId);

            // Additional configurations if needed
        }
    }
}
