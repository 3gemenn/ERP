using ERP.Core.Models;
using ERP.Repository.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.ProjectDbContext
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           


    }
        public DbSet<Material> Material { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OperationWorkforce> OperationWorkforce { get; set; }
        public DbSet<Workforce> Workforce { get; set; }
        public DbSet<WorkOrder> WorkOrder { get; set; }
        public DbSet<ProductionOperation> ProductionOperation { get; set; }
        public DbSet<ProductMaterial> ProductMaterial { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MaterialConfiguration());
            builder.ApplyConfiguration(new OperationWorkforceConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductionOperationConfiguration());
            builder.ApplyConfiguration(new ProductMaterialConfiguration());
            builder.ApplyConfiguration(new WorkforceConfiguration());
            builder.ApplyConfiguration(new WorkOrderConfiguration());
        }
    }
}
