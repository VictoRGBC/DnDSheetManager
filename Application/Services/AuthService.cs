using DnDSheetManager.Application.DTOs;
using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;

namespace DnDSheetManager.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto)
        {
            // Verificar se email já existe
            if (await _userRepository.EmailExistsAsync(registerDto.Email))
                return null;

            // Verificar se username já existe
            if (await _userRepository.UsernameExistsAsync(registerDto.Username))
                return null;

            // Criar usuário
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                CreatedAt = DateTime.UtcNow
            };

            user = await _userRepository.CreateAsync(user);

            // Gerar token
            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            // Buscar usuário por email
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null)
                return null;

            // Verificar senha
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return null;

            // Atualizar último login
            await _userRepository.UpdateLastLoginAsync(user.Id);

            // Gerar token
            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }

        public async Task<UserDto?> GetUserProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt,
                CharacterCount = user.Characters.Count
            };
        }
    }
}
