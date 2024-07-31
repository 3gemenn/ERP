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
    public class ProductionOperationConfiguration : IEntityTypeConfiguration<ProductionOperation>
    {
        public void Configure(EntityTypeBuilder<ProductionOperation> builder)
        {
            // Define the table name
            builder.ToTable("ProductionOperations");

            // Define the primary key
            builder.HasKey(po => po.Id);

            // Define properties
            builder.Property(po => po.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(po => po.WorkOrderId)
                .IsRequired();

            builder.Property(po => po.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(po => po.StartDate)
                .IsRequired(false);

            builder.Property(po => po.EndDate)
                .IsRequired(false);

            builder.Property(po => po.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Define relationships
            builder.HasOne(po => po.WorkOrder)
                .WithMany(wo => wo.ProductionOperations)
                .HasForeignKey(po => po.WorkOrderId);

            builder.HasMany(po => po.OperationWorkforces)
                .WithOne(ow => ow.ProductionOperation)
                .HasForeignKey(ow => ow.OperationId);

            // Additional configurations if needed
        }
    }
}
