using Microsoft.EntityFrameworkCore;
using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;
using DnDSheetManager.Infrastructure.Data;

namespace DnDSheetManager.Infrastructure.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private readonly AppDbContext _context;

        public SpellRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Spell?> GetByIdAsync(int id)
        {
            return await _context.Spells.FindAsync(id);
        }

        public async Task<IEnumerable<Spell>> GetAllAsync()
        {
            return await _context.Spells.ToListAsync();
        }

        public async Task<Spell> AddAsync(Spell spell)
        {
            _context.Spells.Add(spell);
            await _context.SaveChangesAsync();
            return spell;
        }

        public async Task UpdateAsync(Spell spell)
        {
            _context.Spells.Update(spell);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var spell = await _context.Spells.FindAsync(id);
            if (spell != null)
            {
                _context.Spells.Remove(spell);
                await _context.SaveChangesAsync();
            }
        }
    }
}
