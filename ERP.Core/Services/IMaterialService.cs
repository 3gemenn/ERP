using ERP.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IMaterialService
    {
        Task<CustomResponseDto<List<MaterialDto>>> Materials();
        Task<CustomResponseDto<NoContentDto>> Create(MaterialDto dto);
        Task<CustomResponseDto<NoContentDto>> Update(MaterialDto dto);
        Task<CustomResponseDto<NoContentDto>> Delete(string id);
    }
}
