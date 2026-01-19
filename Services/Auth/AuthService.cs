using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RescueSyetem_BE.Models;
using RescueSystem_BE.Dtos.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RescueSystem_BE.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly RescueSystemContext _context;
        private readonly IConfiguration _config;

        public AuthService(RescueSystemContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<LoginResponseDto?> AuthenticateAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive);

            if (user == null || !VerifyPassword(request.Password, user.Password))
                return null;

            var token = GenerateJwtToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                Role = user.Role.RoleCode ?? "" // Return RoleCode for consistency
            };
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.RoleCode ?? ""), // Use RoleCode instead of RoleName for authorization
                new Claim("sub", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return password == hashedPassword;
        }

        // Helper: Hash password (dùng khi create user)
        public string HashPassword(string password)
        {
            // Plain text as requested (NOT recommended for production)
            return password;
        }
    }
}
