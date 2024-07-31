using ERP.Core.Dtos;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IWorkOrderService : IService<WorkOrder>
    {
        Task<CustomResponseDto<List<WorkOrderDto>>> WorkOrders();
        Task<CustomResponseDto<NoContentDto>> Create(WorkOrderDto dto);
        Task<CustomResponseDto<List<SelectProductDto>>> SProduct();
        Task<CustomResponseDto<NoContentDto>> Update(WorkOrderDto dto);
        Task<CustomResponseDto<NoContentDto>> Delete(string id);

    }
}
