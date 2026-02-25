using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.Interfaces;

namespace DnDSheetManager.Application.Services
{
    public interface ICharacterService
    {
        Task<Character?> GetCharacterAsync(int id);
        Task<IEnumerable<Character>> GetCharactersByUserIdAsync(int userId);
        Task<Character> CreateCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(int id, Character character);
        Task<bool> DeleteCharacterAsync(int id);
        Task<bool> AddItemToInventoryAsync(int characterId, int itemId, int quantity);
        Task<Character?> GetCharacterWithInventoryAsync(int id);
        Task<bool> TakeDamageAsync(int id, int amount);
        Task<bool> HealAsync(int id, int amount);
        Task<bool> AddAttackAsync(int characterId, Attack attack);
        Task<bool> AddResourceAsync(int characterId, CharacterResource resource);
        Task<bool> ConsumeResourceAsync(int characterId, int resourceId, int amount);
        Task<bool> RestoreResourceAsync(int characterId, int resourceId, int amount);
        Task<bool> LearnSpellAsync(int characterId, int spellId, bool isPrepared);
        Task<bool> UseSpellSlotAsync(int characterId, int level);
        Task<bool> RestoreSpellSlotAsync(int characterId, int level);
        Task<bool> LongRestAsync(int characterId);
        Task<bool> UseHitDiceAsync(int characterId, int diceCount);
        Task<bool> AddFeatureAsync(int characterId, Feature feature);
        Task<bool> UseFeatureAsync(int characterId, int featureId);
        Task<bool> ShortRestAsync(int characterId);
    }

    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<Character?> GetCharacterAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Character>> GetCharactersByUserIdAsync(int userId) 
            => await _repository.GetByUserIdAsync(userId);

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
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            var existingInventoryItem = character.Inventory.FirstOrDefault(i => i.ItemId == itemId);

            if (existingInventoryItem != null)
            {
                existingInventoryItem.Quantity += quantity;
            }
            else
            {
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
            var character = await _repository.GetByIdWithTrackingAsync(id);
            if (character == null) return false;

            character.TakeDamage(amount);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> HealAsync(int id, int amount)
        {
            var character = await _repository.GetByIdWithTrackingAsync(id);
            if (character == null) return false;

            character.Heal(amount);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> AddAttackAsync(int characterId, Attack attack)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            attack.CharacterId = characterId;
            character.Attacks.Add(attack);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> AddResourceAsync(int characterId, CharacterResource resource)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            resource.CharacterId = characterId;
            character.ClassResources.Add(resource);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> ConsumeResourceAsync(int characterId, int resourceId, int amount)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            var resource = character.ClassResources.FirstOrDefault(r => r.Id == resourceId);
            if (resource == null) return false;

            resource.Consume(amount);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> RestoreResourceAsync(int characterId, int resourceId, int amount)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            var resource = character.ClassResources.FirstOrDefault(r => r.Id == resourceId);
            if (resource == null) return false;

            resource.Restore(amount);

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> LearnSpellAsync(int characterId, int spellId, bool isPrepared)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            var existingSpell = character.Spells.FirstOrDefault(s => s.SpellId == spellId);

            if (existingSpell != null)
            {
                existingSpell.IsPrepared = isPrepared;
            }
            else
            {
                character.Spells.Add(new CharacterSpell
                {
                    CharacterId = characterId,
                    SpellId = spellId,
                    IsPrepared = isPrepared
                });
            }

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> UseSpellSlotAsync(int characterId, int level)
        {
            var character = await _repository.GetByIdWithTrackingAsync(characterId);
            if (character == null) return false;

            bool success = character.SpellSlots.UseSlot(level);
            if (!success) return false;

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> RestoreSpellSlotAsync(int characterId, int level)
        {
            var character = await _repository.GetByIdWithTrackingAsync(characterId);
            if (character == null) return false;

            character.SpellSlots.RestoreSlot(level);
            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> LongRestAsync(int characterId)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            character.LongRest();

            foreach (var feature in character.Features)
            {
                feature.RestoreUses();
            }

            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> UseHitDiceAsync(int characterId, int diceCount)
        {
            var character = await _repository.GetByIdWithTrackingAsync(characterId);
            if (character == null) return false;

            if (character.AvailableHitDice < diceCount) return false;

            character.UseHitDice(diceCount);
            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> AddFeatureAsync(int characterId, Feature feature)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            feature.CharacterId = characterId;
            character.Features.Add(feature);
            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> UseFeatureAsync(int characterId, int featureId)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            var feature = character.Features.FirstOrDefault(f => f.Id == featureId);
            if (feature == null) return false;

            feature.Use();
            await _repository.UpdateAsync(character);
            return true;
        }

        public async Task<bool> ShortRestAsync(int characterId)
        {
            var character = await _repository.GetCharacterWithInventoryTrackingAsync(characterId);
            if (character == null) return false;

            character.ShortRest();

            foreach (var feature in character.Features.Where(f => f.RestType == "Short"))
            {
                feature.RestoreUses();
            }

            await _repository.UpdateAsync(character);
            return true;
        }
    }
}