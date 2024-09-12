using ERP.Core.Models;
using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Core.UnitOfWorks;
using ERP.Repository.ProjectDbContext;
using ERP.Repository.Repositories;
using ERP.Repository.UnitOfWorks;
using ERP.Service.Mapping;
using ERP.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnectionString"]);
});
builder.Services.AddControllers();
builder.Services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericRepository<Material>, GenericRepository<Material>>();
builder.Services.AddScoped<IGenericRepository<ProductMaterial>, GenericRepository<ProductMaterial>>();
builder.Services.AddScoped<IGenericRepository<WorkOrder>, GenericRepository<WorkOrder>>();
builder.Services.AddScoped<IGenericRepository<ProductionOperation>, GenericRepository<ProductionOperation>>();
builder.Services.AddScoped<IGenericRepository<Workforce>, GenericRepository<Workforce>>();
builder.Services.AddScoped<IGenericRepository<OperationWorkforce>, GenericRepository<OperationWorkforce>>();

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IMaterialService,MaterialService>();
builder.Services.AddScoped<IProductMaterialService, ProductMaterialService>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();
builder.Services.AddScoped<IProductionOperationService, ProductionOperationService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IWorkforceService, WorkforceService>();
builder.Services.AddScoped<IOperationWorkforceService, OperationWorkforceService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
