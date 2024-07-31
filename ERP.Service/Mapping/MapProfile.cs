using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserGetDto, User>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<MaterialDto, Material>();
            CreateMap<Material, MaterialDto>();
            CreateMap<ProductMaterial, ProductMaterialDto>();
            CreateMap<ProductMaterialDto, ProductMaterial>();

            CreateMap<SelectMaterialDto, Material>();
            CreateMap<Material, SelectMaterialDto>();
            CreateMap<SelectProductDto, Product>();
            CreateMap<Product, SelectProductDto>();

            CreateMap<WorkOrder, WorkOrderDto>();
            CreateMap<WorkOrderDto, WorkOrder>();

            CreateMap<WorkOrder, SelectWorkOrderDto>();
            CreateMap<SelectWorkOrderDto, WorkOrder>();  

            CreateMap<ProductionOperationDto,ProductionOperation>();
            CreateMap<ProductionOperation, ProductionOperationDto>();


            CreateMap<RoleDto,Role>();
            CreateMap<Role, RoleDto>();


            CreateMap<WorkforceDto, Workforce>();
            CreateMap<Workforce, WorkforceDto>();

            CreateMap<SelectUserDto, User>();
            CreateMap<User, SelectUserDto>();

            

        }
    }
}
