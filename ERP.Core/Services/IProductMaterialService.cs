﻿using ERP.Core.Dtos;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IProductMaterialService : IService<ProductMaterial>
    {
        Task<CustomResponseDto<List<ProductMaterialDto>>> ProductMaterials();
        Task<CustomResponseDto<NoContentDto>> Create(ProductMaterialDto dto);
        Task<CustomResponseDto<List<SelectMaterialDto>>> SMaterial();
        Task<CustomResponseDto<List<SelectProductDto>>> SProduct();
        Task<CustomResponseDto<NoContentDto>> Update(ProductMaterialDto dto);
        Task<CustomResponseDto<NoContentDto>> Delete(string id);
    }
}
