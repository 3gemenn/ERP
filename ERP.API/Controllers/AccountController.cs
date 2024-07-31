using ERP.Core.Dtos.Account;
using ERP.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
       

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameterDto dto)
        {
            return Ok(await _userService.Register(dto));
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginParameterDto dto)
        {
            return Ok(await _userService.Login(dto));
        }
    }
}
