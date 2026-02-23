using DnDSheetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using DnDSheetManager.Domain.Interfaces;
using DnDSheetManager.Infrastructure.Repositories;
using DnDSheetManager.Application.Services;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICharacterService, CharacterService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.Title = "DnD Sheet Manager API";
    options.Theme = ScalarTheme.BluePlanet;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();