using DnDSheetManager.Application.DTOs;

namespace DnDSheetManager.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
        Task<UserDto?> GetUserProfileAsync(int userId);
    }
}
