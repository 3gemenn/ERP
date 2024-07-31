using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IWorkforceService : IService<Workforce>
    {
        Task<CustomResponseDto<List<WorkforceDto>>> Workforces();
        Task<CustomResponseDto<List<RoleDto>>> SelectRole();
        Task<CustomResponseDto<List<SelectUserDto>>> SelectUser();
        Task<CustomResponseDto<NoContentDto>> Create(WorkforceDto dto);

    }
}
