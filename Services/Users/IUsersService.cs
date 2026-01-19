using RescueSystem_BE.Dtos.Users;

namespace RescueSystem_BE.Services.Users
{
    public interface IUsersService
    {
        Task<IReadOnlyList<UserDto>> GetUsersAsync(string? roleCode = null);
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<(bool ok, string? error, UserDto? user)> CreateUserAsync(CreateUserDto dto);
        Task<(bool ok, string? error, UserDto? user)> UpdateUserAsync(Guid id, UpdateUserDto dto);
        Task<(bool ok, string? error)> DeactivateUserAsync(Guid id);
    }
}

