using EmpBAL.Dtos;
using EmpBAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpCoreThreeTire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var response = _authService.RegisterUserService(registerDto);
            return !response.Success ? BadRequest(response) : Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var response = _authService.LoginUserService(loginDto);
            return !response.Success ? BadRequest(response) : Ok(response);
        }
    }
}
