using DnDSheetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DnDSheetManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CharacterItem> CharacterItems { get; set; }

        public DbSet<Attack> Attacks { get; set; }
        public DbSet<CharacterResource> CharacterResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CharacterItem>()
                .HasKey(ci => new { ci.CharacterId, ci.ItemId });

            modelBuilder.Entity<CharacterItem>()
                .HasOne(ci => ci.Character)
                .WithMany(c => c.Inventory)
                .HasForeignKey(ci => ci.CharacterId);

            modelBuilder.Entity<CharacterItem>()
                .HasOne(ci => ci.Item)
                .WithMany(i => i.CharacterItems)
                .HasForeignKey(ci => ci.ItemId);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Attacks)
                .WithOne(a => a.Character)
                .HasForeignKey(a => a.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.ClassResources)
                .WithOne(r => r.Character)
                .HasForeignKey(r => r.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>().OwnsOne(c => c.Abilities);
            modelBuilder.Entity<Character>().OwnsOne(c => c.Wealth);
            modelBuilder.Entity<Character>().OwnsOne(c => c.Skills);
        }
    }
}