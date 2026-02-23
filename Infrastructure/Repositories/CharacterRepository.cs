using Microsoft.EntityFrameworkCore;
using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;
using DnDSheetManager.Infrastructure.Data;

namespace DnDSheetManager.Infrastructure.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _context;

        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Character?> GetByIdAsync(int id) => await _context.Characters.FindAsync(id);

        public async Task<Character> AddAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }
    }
}