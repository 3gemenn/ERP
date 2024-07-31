using ERP.Core.Dtos;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IProductionOperationService : IService<ProductionOperation>
    {
        Task<CustomResponseDto<List<ProductionOperationDto>>> ProductionOperations();
        Task<CustomResponseDto<NoContentDto>> Create(ProductionOperationDto dto);
        Task<CustomResponseDto<List<SelectWorkOrderDto>>> SWorkOrder();
        Task<CustomResponseDto<NoContentDto>> Update(ProductionOperationDto dto);
        Task<CustomResponseDto<NoContentDto>> Delete(string id);
    }
}
