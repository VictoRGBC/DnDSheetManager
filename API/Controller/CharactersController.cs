using Microsoft.AspNetCore.Mvc;
using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Application.Services;

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

        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character character)
        {
            var createdCharacter = await _characterService.CreateCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _characterService.GetCharacterAsync(id);
            if (character == null) return NotFound();
            return Ok(character);
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
    }
}