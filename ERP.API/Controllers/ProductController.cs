using ERP.Core.Dtos;
using ERP.Core.Models;
using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            return Ok(await _productService.Products());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            return Ok(await _productService.Create(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            return Ok(await _productService.Update(dto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productService.Delete(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
