using DnDSheetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DnDSheetManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
    }
}