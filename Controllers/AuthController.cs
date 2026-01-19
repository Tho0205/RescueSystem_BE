using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Dtos.Auth;
using RescueSystem_BE.Services.Auth;
using System.Security.Claims;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.AuthenticateAsync(request);
            if (result == null)
                return Unauthorized(new { message = "Sai tài khoản/mật khẩu" });

            return Ok(result);
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult Profile()
        {
            var userIdClaim = User.FindFirst("UserId")?.Value ??
                              User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new
            {
                UserId = userIdClaim,
                Username = User.Identity?.Name,
                Roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value),
                Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToArray()
            });
        }

    }
}
