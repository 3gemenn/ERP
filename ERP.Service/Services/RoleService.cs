using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Models;
using ERP.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
{
    public class RoleService :IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager,IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(RoleDto dto)
        {
            
            var role = new Role
            {
                Name=dto.Name
            };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return CustomResponseDto<NoContentDto>.Success(200);
            }

            else
            {
                var error = "";
                foreach (var item in result.Errors)
                {
                    error += item.Description + " ";
                }
                return CustomResponseDto<NoContentDto>.Fail(400, error);
            };
        }
    }
}
