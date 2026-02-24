using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;

namespace DnDSheetManager.Application.Services
{
    public interface ICharacterService
    {
        Task<Character?> GetCharacterAsync(int id);
        Task<Character> CreateCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(int id, Character character);
        Task<bool> DeleteCharacterAsync(int id);
        Task<bool> AddItemToInventoryAsync(int characterId, int itemId, int quantity);
        Task<Character?> GetCharacterWithInventoryAsync(int id);
        Task<bool> TakeDamageAsync(int id, int amount);
        Task<bool> HealAsync(int id, int amount);
        Task<bool> AddAttackAsync(int characterId, Attack attack);
        Task<bool> AddResourceAsync(int characterId, CharacterResource resource);
    }

    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<Character?> GetCharacterAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<Character> CreateCharacterAsync(Character character)
        {
            // Futuramente: Adicionar validações de regras de D&D aqui
            return await _repository.AddAsync(character);
        }

        public async Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            if (id != character.Id) return false;

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> AddItemToInventoryAsync(int characterId, int itemId, int quantity)
        {
            // Busca o personagem com o inventário carregado
            var character = await _repository.GetCharacterWithInventoryAsync(characterId);
            if (character == null) return false;

            // Verifica se ele já possui o item na bolsa
            var existingInventoryItem = character.Inventory.FirstOrDefault(i => i.ItemId == itemId);

            if (existingInventoryItem != null)
            {
                existingInventoryItem.Quantity += quantity;
            }
            else
            {
                // Adiciona um item novo na lista
                character.Inventory.Add(new CharacterItem
                {
                    CharacterId = characterId,
                    ItemId = itemId,
                    Quantity = quantity
                });
            }

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<Character?> GetCharacterWithInventoryAsync(int id)
        {
            return await _repository.GetCharacterWithInventoryAsync(id);
        }

        public async Task<bool> TakeDamageAsync(int id, int amount)
        {
            var character = await _repository.GetByIdAsync(id);
            if (character == null) return false;

            character.TakeDamage(amount);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> HealAsync(int id, int amount)
        {
            var character = await _repository.GetByIdAsync(id);
            if (character == null) return false;

            character.Heal(amount);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> AddAttackAsync(int characterId, Attack attack)
        {
            var character = await _repository.GetCharacterWithInventoryAsync(characterId);
            if (character == null) return false;

            attack.CharacterId = characterId;
            character.Attacks.Add(attack);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> AddResourceAsync(int characterId, CharacterResource resource)
        {
            var character = await _repository.GetCharacterWithInventoryAsync(characterId);
            if (character == null) return false;

            resource.CharacterId = characterId;
            character.ClassResources.Add(resource);

            await _repository.UpdateAsync(character);
            return true;
        }
    }
}