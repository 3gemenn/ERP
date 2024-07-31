using ERP.Core.Dtos;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IProductService :IService<Product>
    {
        Task<CustomResponseDto<List<ProductDto>>> Products();
        Task<CustomResponseDto<NoContentDto>> Create(ProductDto dto);
        Task<CustomResponseDto<NoContentDto>> Update(ProductDto dto);
        Task<CustomResponseDto<NoContentDto>> Delete(string id);
    }
}
