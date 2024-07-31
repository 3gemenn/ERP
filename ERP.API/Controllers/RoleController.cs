using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto dto)
        {
            return Ok(await _roleService.Create(dto));
        }
    }
}
