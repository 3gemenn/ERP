using ERP.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IRoleService
    {
       Task<CustomResponseDto<NoContentDto>> Create(RoleDto dto);

    }
}
