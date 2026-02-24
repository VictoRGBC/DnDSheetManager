using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;

namespace DnDSheetManager.Application.Services
{
    public interface IItemService
    {
        Task<Item?> GetItemAsync(int id);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> CreateItemAsync(Item item);
        Task<bool> UpdateItemAsync(int id, Item item);
        Task<bool> DeleteItemAsync(int id);
    }

    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Item?> GetItemAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            return await _repository.AddAsync(item);
        }

        public async Task<bool> UpdateItemAsync(int id, Item item)
        {
            if (id != item.Id) return false;

            var exists = await _repository.ExistsAsync(id);
            if (!exists) return false;

            await _repository.UpdateAsync(item);
            return true;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
