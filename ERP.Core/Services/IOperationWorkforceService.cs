using ERP.Core.Dtos;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IOperationWorkforceService : IService<OperationWorkforce>
    {
        Task<CustomResponseDto<List<OperationWorkforceDto>>> OperationWorkforces();
        Task<CustomResponseDto<List<OperationDto>>> SOperation();
        Task<CustomResponseDto<List<SelectWorkforceDto>>> SWorkforce();
        Task<CustomResponseDto<NoContentDto>> Create(OperationWorkforceDto dto);
    }
}
