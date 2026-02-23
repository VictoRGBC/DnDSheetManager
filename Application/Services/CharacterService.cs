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
    }

    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        // Injetamos o repositório aqui. A camada de aplicação não sabe que é o Entity Framework!
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
    }
}