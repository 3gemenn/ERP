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
    public class OperationWorkforceConfiguration : IEntityTypeConfiguration<OperationWorkforce>
    {
        public void Configure(EntityTypeBuilder<OperationWorkforce> builder)
        {
            // Define the table name
            builder.ToTable("OperationWorkforces");

            // Define the primary key
            builder.HasKey(ow => ow.Id);

            // Define properties
            builder.Property(ow => ow.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ow => ow.OperationId)
                .IsRequired();

            builder.Property(ow => ow.WorkforceId)
                .IsRequired();

            builder.Property(ow => ow.HoursWorked)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Define relationships
            builder.HasOne(ow => ow.ProductionOperation)
                .WithMany(po => po.OperationWorkforces)
                .HasForeignKey(ow => ow.OperationId);

            builder.HasOne(ow => ow.Workforce)
                .WithMany(wf => wf.OperationWorkforces)
                .HasForeignKey(ow => ow.WorkforceId);

            // Additional configurations if needed
        }
    }
}
