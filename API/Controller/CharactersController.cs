using DnDSheetManager.API.DTOs;
using DnDSheetManager.Application.Services;
using DnDSheetManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DnDSheetManager.API.DTOs;

namespace DnDSheetManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // Post: api/characters (Cria uma nova ficha)
        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character character)
        {
            var createdCharacter = await _characterService.CreateCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        // GET: api/characters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDto>> GetCharacter(int id)
        {
            // Busca o personagem com os itens incluídos
            var character = await _characterService.GetCharacterWithInventoryAsync(id);

            if (character == null) return NotFound("Personagem não encontrado.");

            // Mapeamento manual de Entidade para DTO
            var responseDto = new CharacterResponseDto
            {
                Id = character.Id,
                Name = character.Name,
                Race = character.Race,
                ClassName = character.ClassName,
                Level = character.Level,
                CurrentHitPoints = character.CurrentHitPoints,
                MaxHitPoints = character.MaxHitPoints,

                // Atributos Base
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                Constitution = character.Constitution,
                Intelligence = character.Intelligence,
                Wisdom = character.Wisdom,
                Charisma = character.Charisma,

                // Aplicando a regra de negócio do Domínio!
                StrengthModifier = character.GetModifier(character.Strength),
                DexterityModifier = character.GetModifier(character.Dexterity),
                ConstitutionModifier = character.GetModifier(character.Constitution),
                IntelligenceModifier = character.GetModifier(character.Intelligence),
                WisdomModifier = character.GetModifier(character.Wisdom),
                CharismaModifier = character.GetModifier(character.Charisma),

                // Mapeia o inventário
                Inventory = character.Inventory.Select(i => new InventoryItemDto
                {
                    ItemId = i.ItemId,
                    Name = i.Item?.Name ?? "Item Desconhecido",
                    Quantity = i.Quantity,
                    TotalWeight = (i.Item?.Weight ?? 0) * i.Quantity
                }).ToList()
            };

            return Ok(responseDto);
        }

        // PUT: api/characters/{id} (Atualiza a ficha, ex: tomou dano, subiu de nível)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, Character character)
        {
            var updated = await _characterService.UpdateCharacterAsync(id, character);
            if (!updated) return BadRequest("IDs não batem ou personagem não encontrado.");

            return NoContent();
        }

        // DELETE: api/characters/{id} (Deleta a ficha)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var deleted = await _characterService.DeleteCharacterAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        // POST: api/characters/{id}/inventory
        [HttpPost("{id}/inventory")]
        public async Task<IActionResult> AddItemToInventory(int id, [FromBody] AddItemDto dto)
        {
            var success = await _characterService.AddItemToInventoryAsync(id, dto.ItemId, dto.Quantity);

            if (!success)
                return BadRequest("Personagem não encontrado ou erro ao adicionar o item.");

            return Ok("Item adicionado ao inventário com sucesso!");
        }
    }
}