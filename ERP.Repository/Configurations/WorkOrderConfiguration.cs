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
    public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            // Define the table name
            builder.ToTable("WorkOrders");

            // Define the primary key
            builder.HasKey(wo => wo.Id);

            // Define properties
            builder.Property(wo => wo.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(wo => wo.ProductId)
                .IsRequired();

            builder.Property(wo => wo.Quantity)
                .IsRequired();

            builder.Property(wo => wo.StartDate)
                .IsRequired(false);

            builder.Property(wo => wo.EndDate)
                .IsRequired(false);

            builder.Property(wo => wo.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Define relationships
            builder.HasOne(wo => wo.Product)
                .WithMany(p => p.WorkOrders)
                .HasForeignKey(wo => wo.ProductId);

            builder.HasMany(wo => wo.ProductionOperations)
                .WithOne(po => po.WorkOrder)
                .HasForeignKey(po => po.WorkOrderId);

            // Additional configurations if needed
        }
    }
}
