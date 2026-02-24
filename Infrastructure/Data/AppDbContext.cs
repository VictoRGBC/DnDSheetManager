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

        public DbSet<Spell> Spells { get; set; }
        public DbSet<CharacterSpell> CharacterSpells { get; set; }

        public DbSet<Feature> Features { get; set; }

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

            modelBuilder.Entity<CharacterSpell>()
                .HasKey(cs => new { cs.CharacterId, cs.SpellId });

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(cs => cs.Character)
                .WithMany(c => c.Spells)
                .HasForeignKey(cs => cs.CharacterId);

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(cs => cs.Spell)
                .WithMany(s => s.CharacterSpells)
                .HasForeignKey(cs => cs.SpellId);

            modelBuilder.Entity<Character>().OwnsOne(c => c.Abilities);
            modelBuilder.Entity<Character>().OwnsOne(c => c.Wealth);
            modelBuilder.Entity<Character>().OwnsOne(c => c.Skills);
            modelBuilder.Entity<Character>().OwnsOne(c => c.SavingThrows);
            modelBuilder.Entity<Character>().OwnsOne(c => c.SpellSlots);
            modelBuilder.Entity<Character>().OwnsOne(c => c.AC);
            modelBuilder.Entity<Character>().OwnsOne(c => c.Conditions);
            modelBuilder.Entity<Character>().OwnsOne(c => c.DamageResistances, dr =>
            {
                dr.Property(d => d.Resistances).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

                dr.Property(d => d.Immunities).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

                dr.Property(d => d.Vulnerabilities).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Features)
                .WithOne(f => f.Character)
                .HasForeignKey(f => f.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}