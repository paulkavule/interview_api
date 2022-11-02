using System;
using Interview.Api.Dtos;
using Interview.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService svc;

        public LoginController(ILoginService svc)
        {
            this.svc = svc;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var result = await svc.Login(dto);
            var status = result == null ? StatusCodes.Status403Forbidden : StatusCodes.Status200OK;

            return StatusCode(status, result);
        }
    }
}

