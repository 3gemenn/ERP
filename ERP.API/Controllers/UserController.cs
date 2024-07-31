using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using ERP.Core.Models;
using ERP.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
      


        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _userService.GetById(id));
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            return Ok(await _userService.Users());
        }
        [HttpPut]
        public async Task<IActionResult> Update( UserGetDto dto)
        {
            return Ok(await _userService.Update(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.Delete(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
