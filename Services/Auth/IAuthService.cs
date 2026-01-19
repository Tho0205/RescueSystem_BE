using RescueSyetem_BE.Models;
using RescueSystem_BE.Dtos.Auth;

namespace RescueSystem_BE.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> AuthenticateAsync(LoginRequestDto request);
        string GenerateJwtToken(User user);
    }
}
