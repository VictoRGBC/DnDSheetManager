using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;

namespace DnDSheetManager.Application.Services
{
    public interface ISpellService
    {
        Task<Spell?> GetSpellAsync(int id);
        Task<IEnumerable<Spell>> GetAllSpellsAsync();
        Task<Spell> CreateSpellAsync(Spell spell);
        Task<bool> UpdateSpellAsync(int id, Spell spell);
        Task<bool> DeleteSpellAsync(int id);
    }

    public class SpellService : ISpellService
    {
        private readonly ISpellRepository _repository;

        public SpellService(ISpellRepository repository)
        {
            _repository = repository;
        }

        public async Task<Spell?> GetSpellAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Spell>> GetAllSpellsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Spell> CreateSpellAsync(Spell spell)
        {
            return await _repository.AddAsync(spell);
        }

        public async Task<bool> UpdateSpellAsync(int id, Spell spell)
        {
            if (id != spell.Id) return false;

            await _repository.UpdateAsync(spell);
            return true;
        }

        public async Task<bool> DeleteSpellAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
