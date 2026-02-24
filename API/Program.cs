using DnDSheetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using DnDSheetManager.Domain.Interfaces;
using DnDSheetManager.Infrastructure.Repositories;
using DnDSheetManager.Application.Services;
using DnDSheetManager.Domain.Services;
using DnDSheetManager.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICharacterService, CharacterService>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddScoped<ISpellRepository, SpellRepository>();
builder.Services.AddScoped<ISpellService, SpellService>();

builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICharacterService, CharacterService>();

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
app.UseAuthorization();
app.MapControllers();

app.Run();