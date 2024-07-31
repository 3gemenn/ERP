using ERP.Core.Dtos;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkforceController : ControllerBase
    {

        private readonly IWorkforceService _workforceService;

        public WorkforceController(IWorkforceService workforceService)
        {
            _workforceService = workforceService;
        }

        [HttpGet]
        public async Task<IActionResult> Workforces()
        {
            return Ok(await _workforceService.Workforces());
        }

        [HttpGet]
        public async Task<IActionResult> SelectUser()
        {
            return Ok(await _workforceService.SelectUser());
        }
        
        [HttpGet]
        public async Task<IActionResult> SelectRole()
        {
            return Ok(await _workforceService.SelectRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkforceDto dto)
        {
            return Ok(await _workforceService.Create(dto));
        }
    }
}
