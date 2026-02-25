using DnDSheetManager.Application.DTOs;
using DnDSheetManager.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DnDSheetManager.API.Controller
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

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(registerDto);

            if (result == null)
                return BadRequest("Email ou nome de usuário já em uso.");

            return CreatedAtAction(nameof(GetProfile), new { }, result);
        }

        /// <summary>
        /// Faz login de um usuário existente
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(loginDto);

            if (result == null)
                return Unauthorized("Email ou senha inválidos.");

            return Ok(result);
        }

        /// <summary>
        /// Retorna o perfil do usuário autenticado
        /// </summary>
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (userIdClaim == null)
                return Unauthorized();

            var userId = int.Parse(userIdClaim);
            var profile = await _authService.GetUserProfileAsync(userId);

            if (profile == null)
                return NotFound("Usuário não encontrado.");

            return Ok(profile);
        }

        /// <summary>
        /// Endpoint para testar se o token está válido
        /// </summary>
        [Authorize]
        [HttpGet("validate")]
        public IActionResult ValidateToken()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            
            return Ok(new
            {
                valid = true,
                userId = userId,
                username = username
            });
        }
    }
}
