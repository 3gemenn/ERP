﻿using ERP.Core.Dtos;
using ERP.Core.Services;
using ERP.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationWorkforceController : ControllerBase
    {
        private readonly IOperationWorkforceService _operationWorkforceService;

        public OperationWorkforceController(IOperationWorkforceService operationWorkforceService)
        {
            _operationWorkforceService = operationWorkforceService;
        }
        [HttpGet]
        public async Task<IActionResult> OperationWorkforces()
        {
            return Ok(await _operationWorkforceService.OperationWorkforces());
        }
        [HttpGet]
        public async Task<IActionResult> SOperation()
        {
            return Ok(await _operationWorkforceService.SOperation());
        }
        [HttpGet]
        public async Task<IActionResult> SWorkforce()
        {
            return Ok(await _operationWorkforceService.SWorkforce());
        }
        [HttpPost]
        public async Task<IActionResult> Create(OperationWorkforceDto dto)
        { 
            return Ok(await _operationWorkforceService.Create(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(OperationWorkforceDto dto)
        {
            return Ok(await _operationWorkforceService.Update(dto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _operationWorkforceService.Delete(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
