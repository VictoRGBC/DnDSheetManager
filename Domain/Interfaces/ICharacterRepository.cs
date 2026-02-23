using DnDSheetManager.Domain.Entities;

namespace DnDSheetManager.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<Character?> GetByIdAsync(int id);
        Task<Character> AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);
    }
}