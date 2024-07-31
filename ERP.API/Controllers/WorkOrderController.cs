using ERP.Core.Dtos;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {

        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workorderservice)
        {
            _workOrderService = workorderservice;

        }
        [HttpGet]
        public async Task<IActionResult> WorkOrders()
        {
            return Ok(await _workOrderService.WorkOrders());
        }

        [HttpGet]
        public async Task<IActionResult> SelectProduct()
        {
            return Ok(await _workOrderService.SProduct());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(WorkOrderDto dto)
        {
            return Ok(await _workOrderService.Create(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(WorkOrderDto dto)
        {
            return Ok(await _workOrderService.Update(dto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _workOrderService.Delete(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
