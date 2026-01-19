using Microsoft.EntityFrameworkCore;
using RescueSyetem_BE.Models;
using RescueSystem_BE.Dtos.Users;
using RescueSystem_BE.Services.Auth;

namespace RescueSystem_BE.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly RescueSystemContext _context;
        private readonly IAuthService _authService;

        public UsersService(RescueSystemContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<IReadOnlyList<UserDto>> GetUsersAsync(string? roleCode = null)
        {
            var query = _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(roleCode))
                query = query.Where(u => u.Role.RoleCode == roleCode);

            return await query
                .OrderByDescending(u => u.CreatedAt)
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
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .Where(u => u.UserId == id)
                .Select(u => new UserDto
                {
                    UserID = u.UserId,
                    Username = u.Username,
                    FullName = u.FullName,
                    Phone = u.Phone,
                    RoleName = u.Role.RoleName,
                    IsActive = u.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool ok, string? error, UserDto? user)> CreateUserAsync(CreateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return (false, "Username/Password is required", null);

            var exists = await _context.Users.AnyAsync(u => u.Username == dto.Username);
            if (exists) return (false, "Username already exists", null);

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == dto.RoleID);
            if (role == null) return (false, "Invalid RoleID", null);

            var user = new User
            {
                Username = dto.Username.Trim(),
                Password = _authService.HashPassword(dto.Password),
                FullName = dto.FullName.Trim(),
                Phone = dto.Phone,
                RoleId = dto.RoleID,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // reload role name
            var created = await GetUserByIdAsync(user.UserId);
            return (true, null, created);
        }

        public async Task<(bool ok, string? error, UserDto? user)> UpdateUserAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null) return (false, "User not found", null);

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == dto.RoleID);
            if (role == null) return (false, "Invalid RoleID", null);

            user.FullName = dto.FullName.Trim();
            user.Phone = dto.Phone;
            user.RoleId = dto.RoleID;
            user.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            var updated = await GetUserByIdAsync(id);
            return (true, null, updated);
        }

        public async Task<(bool ok, string? error)> DeactivateUserAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null) return (false, "User not found");

            user.IsActive = false;
            await _context.SaveChangesAsync();
            return (true, null);
        }
    }
}

