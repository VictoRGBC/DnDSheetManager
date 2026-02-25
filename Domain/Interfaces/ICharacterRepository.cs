using DnDSheetManager.Domain.Entities;

namespace DnDSheetManager.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<Character?> GetByIdAsync(int id);
        Task<IEnumerable<Character>> GetByUserIdAsync(int userId);
        Task<Character?> GetByIdWithTrackingAsync(int id);
        Task<Character> AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);
        Task<Character?> GetCharacterWithInventoryAsync(int id);
        Task<Character?> GetCharacterWithInventoryTrackingAsync(int id);
    }
}