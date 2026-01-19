
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueSyetem_BE.Models;
using RescueSystem_BE.Dtos.Users;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RescueSystemContext _context;

        public UsersController(RescueSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Select(u => new UserDto
                {
                    UserID = u.UserId,
                    Username = u.Username,
                    FullName = u.FullName,
                    Phone = u.Phone,
                    RoleName = u.Role.RoleName,
                    IsActive = u.IsActive
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null) return NotFound();

            var dto = new UserDto
            {
                UserID = user.UserId,
                Username = user.Username,
                FullName = user.FullName,
                Phone = user.Phone,
                RoleName = user.Role.RoleName,
                IsActive = user.IsActive
            };

            return Ok(dto);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto dto)
        {
            return Ok("ADMIN only");
        }
    }
}
