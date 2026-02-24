using DnDSheetManager.API.DTOs;
using DnDSheetManager.Application.Services;
using DnDSheetManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

        // POST: api/characters
        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> CreateCharacter(Character character)
        {
            var createdCharacter = await _characterService.CreateCharacterAsync(character);

            var responseDto = MapToResponseDto(createdCharacter);

            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, responseDto);
        }

        // GET: api/characters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDto>> GetCharacter(int id)
        {
            var character = await _characterService.GetCharacterWithInventoryAsync(id);
            if (character == null) return NotFound("Personagem não encontrado.");

            var responseDto = MapToResponseDto(character);

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

        // PATCH: api/characters/{id}/take-damage
        [HttpPatch("{id}/take-damage")]
        public async Task<IActionResult> TakeDamage(int id, [FromBody] CharacterActionDto dto)
        {
            if (dto.Amount <= 0) return BadRequest("O valor do dano deve ser maior que zero.");

            var success = await _characterService.TakeDamageAsync(id, dto.Amount);
            if (!success) return NotFound("Personagem não encontrado.");

            return Ok($"Dano de {dto.Amount} aplicado com sucesso.");
        }

        // PATCH: api/characters/{id}/heal
        [HttpPatch("{id}/heal")]
        public async Task<IActionResult> Heal(int id, [FromBody] CharacterActionDto dto)
        {
            if (dto.Amount <= 0) return BadRequest("O valor da cura deve ser maior que zero.");

            var success = await _characterService.HealAsync(id, dto.Amount);
            if (!success) return NotFound("Personagem não encontrado.");

            return Ok($"Cura de {dto.Amount} aplicada com sucesso.");
        }

        // POST: api/characters/{id}/attacks
        [HttpPost("{id}/attacks")]
        public async Task<IActionResult> AddAttack(int id, [FromBody] CreateAttackDto dto)
        {
            var attack = new Attack
            {
                Name = dto.Name,
                AttackBonus = dto.AttackBonus,
                Damage = dto.Damage,
                DamageType = dto.DamageType,
                Properties = dto.Properties
            };

            var success = await _characterService.AddAttackAsync(id, attack);
            if (!success) return NotFound("Personagem não encontrado.");

            return Ok("Ataque adicionado com sucesso!");
        }

        // POST: api/characters/{id}/resources
        [HttpPost("{id}/resources")]
        public async Task<IActionResult> AddResource(int id, [FromBody] CreateResourceDto dto)
        {
            var resource = new CharacterResource
            {
                Name = dto.Name,
                MaxValue = dto.MaxValue,
                CurrentValue = dto.CurrentValue
            };

            var success = await _characterService.AddResourceAsync(id, resource);
            if (!success) return NotFound("Personagem não encontrado.");

            return Ok("Recurso adicionado com sucesso!");
        }

        // Método privado para evitar repetição de código
        private CharacterResponseDto MapToResponseDto(Character character)
        {
            return new CharacterResponseDto
            {
                Id = character.Id,
                Name = character.Name,
                Species = character.Species,
                ClassName = character.ClassName,
                Level = character.Level,
                CurrentHitPoints = character.CurrentHitPoints,
                MaxHitPoints = character.MaxHitPoints,

                Abilities = new AbilityScoresDto
                {
                    Strength = character.Abilities.Strength,
                    StrengthModifier = character.GetModifier(character.Abilities.Strength),
                    Dexterity = character.Abilities.Dexterity,
                    DexterityModifier = character.GetModifier(character.Abilities.Dexterity),
                    Constitution = character.Abilities.Constitution,
                    ConstitutionModifier = character.GetModifier(character.Abilities.Constitution),
                    Intelligence = character.Abilities.Intelligence,
                    IntelligenceModifier = character.GetModifier(character.Abilities.Intelligence),
                    Wisdom = character.Abilities.Wisdom,
                    WisdomModifier = character.GetModifier(character.Abilities.Wisdom),
                    Charisma = character.Abilities.Charisma,
                    CharismaModifier = character.GetModifier(character.Abilities.Charisma)
                },

                Wealth = new CoinsDto
                {
                    CopperPieces = character.Wealth.CopperPieces,
                    SilverPieces = character.Wealth.SilverPieces,
                    ElectrumPieces = character.Wealth.ElectrumPieces,
                    GoldPieces = character.Wealth.GoldPieces,
                    PlatinumPieces = character.Wealth.PlatinumPieces
                },

                Inventory = character.Inventory?.Select(i => new InventoryItemDto
                {
                    ItemId = i.ItemId,
                    Name = i.Item?.Name ?? "Item Desconhecido",
                    Quantity = i.Quantity,
                    TotalWeight = (i.Item?.Weight ?? 0) * i.Quantity
                }).ToList() ?? new List<InventoryItemDto>(),

                Attacks = character.Attacks?.Select(a => new AttackResponseDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    AttackBonus = a.AttackBonus,
                    Damage = a.Damage,
                    DamageType = a.DamageType,
                    Properties = a.Properties
                }).ToList() ?? new List<AttackResponseDto>(),

                ClassResources = character.ClassResources?.Select(r => new ResourceResponseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    MaxValue = r.MaxValue,
                    CurrentValue = r.CurrentValue
                }).ToList() ?? new List<ResourceResponseDto>()
            };
        }
    }
}