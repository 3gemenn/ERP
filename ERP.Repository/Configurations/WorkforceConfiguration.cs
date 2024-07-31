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
    public class WorkforceConfiguration : IEntityTypeConfiguration<Workforce>
    {
        public void Configure(EntityTypeBuilder<Workforce> builder)
        {
            // Define the table name
            builder.ToTable("Workforces");

            // Define the primary key
            builder.HasKey(wf => wf.Id);

            // Define properties
            builder.Property(wf => wf.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(wf => wf.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(wf => wf.Role)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(wf => wf.HourlyRate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Define relationships
            builder.HasMany(wf => wf.OperationWorkforces)
                .WithOne(ow => ow.Workforce)
                .HasForeignKey(ow => ow.WorkforceId);

            // Additional configurations if needed
        }
    }
}
