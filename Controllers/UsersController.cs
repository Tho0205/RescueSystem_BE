
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Dtos.Users;
using RescueSystem_BE.Services.Users;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] string? roleCode = null)
        {
            var users = await _usersService.GetUsersAsync(roleCode);
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto dto)
        {
            var (ok, error, user) = await _usersService.CreateUserAsync(dto);
            if (!ok) return BadRequest(new { message = error });
            return CreatedAtAction(nameof(GetUser), new { id = user!.UserID }, user);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserDto>> UpdateUser(Guid id, [FromBody] UpdateUserDto dto)
        {
            var (ok, error, user) = await _usersService.UpdateUserAsync(id, dto);
            if (!ok) return error == "User not found" ? NotFound(new { message = error }) : BadRequest(new { message = error });
            return Ok(user);
        }

        [HttpPatch("{id:guid}/deactivate")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            var (ok, error) = await _usersService.DeactivateUserAsync(id);
            if (!ok) return NotFound(new { message = error });
            return NoContent();
        }
    }
}
