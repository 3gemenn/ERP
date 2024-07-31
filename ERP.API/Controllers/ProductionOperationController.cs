using ERP.Core.Dtos;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductionOperationController : ControllerBase
    {
        private readonly IProductionOperationService _productionOperationService;

        public ProductionOperationController(IProductionOperationService productionOperationService)
        {
            _productionOperationService = productionOperationService;

        }
        [HttpGet]
        public async Task<IActionResult> ProductionOperations()
        {
            return Ok(await _productionOperationService.ProductionOperations());
        }

        [HttpGet]
        public async Task<IActionResult> SelectWorkOrder()
        {
            return Ok(await _productionOperationService.SWorkOrder());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionOperationDto dto)
        {
            return Ok(await _productionOperationService.Create(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductionOperationDto dto)
        {
            return Ok(await _productionOperationService.Update(dto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productionOperationService.Delete(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
