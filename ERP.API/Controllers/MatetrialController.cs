using ERP.Core.Dtos;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MatetrialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MatetrialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> Materials()
        {
            return Ok(await _materialService.Materials());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialDto dto)
        {
            return Ok(await _materialService.Create(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MaterialDto dto)
        {
            return Ok(await _materialService.Update(dto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _materialService.Delete(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
