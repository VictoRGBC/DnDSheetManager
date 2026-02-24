using DnDSheetManager.Domain.Entities;

namespace DnDSheetManager.Domain.Interfaces
{
    public interface ISpellRepository
    {
        Task<Spell?> GetByIdAsync(int id);
        Task<IEnumerable<Spell>> GetAllAsync();
        Task<Spell> AddAsync(Spell spell);
        Task UpdateAsync(Spell spell);
        Task DeleteAsync(int id);
    }
}
