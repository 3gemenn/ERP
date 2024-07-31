using ERP.Core.Dtos;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductMaterialController : ControllerBase
    {
        private readonly IProductMaterialService _productMaterialService;

        public ProductMaterialController(IProductMaterialService productMaterialService)
        {
            _productMaterialService = productMaterialService;

        }

        [HttpGet]
        public async Task<IActionResult> SelectProduct()
        {
            return Ok(await _productMaterialService.SProduct());
        } 
        
        [HttpGet]
        public async Task<IActionResult> SelectMaterial()
        {
            return Ok(await _productMaterialService.SMaterial());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductMaterialDto dto)
        {
            return Ok(await _productMaterialService.Create(dto));
        }
    }
}
