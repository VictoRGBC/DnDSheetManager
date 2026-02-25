using DnDSheetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using DnDSheetManager.Domain.Interfaces;
using DnDSheetManager.Infrastructure.Repositories;
using DnDSheetManager.Application.Services;
using DnDSheetManager.Domain.Services;
using DnDSheetManager.API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DnDSheetManager.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configuração JWT
var jwtSecretKey = builder.Configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey não configurada");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// Repositórios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ISpellRepository, SpellRepository>();

// Serviços
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ISpellService, SpellService>();

// Serviços de infraestrutura
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICombatCalculator, CombatCalculator>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapOpenApi();

app.UseExceptionHandler();

app.MapScalarApiReference(options =>
{
    options.Title = "DnD Sheet Manager API";
    options.Theme = ScalarTheme.BluePlanet;
});

app.UseHttpsRedirection();

app.UseAuthentication(); // IMPORTANTE: Antes do UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
