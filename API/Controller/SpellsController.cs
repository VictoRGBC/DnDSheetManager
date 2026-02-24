using Microsoft.AspNetCore.Mvc;
using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Application.Services;

namespace DnDSheetManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellsController : ControllerBase
    {
        private readonly ISpellService _spellService;

        public SpellsController(ISpellService spellService)
        {
            _spellService = spellService;
        }

        [HttpPost]
        public async Task<ActionResult<Spell>> CreateSpell(Spell spell)
        {
            var createdSpell = await _spellService.CreateSpellAsync(spell);
            return CreatedAtAction(nameof(GetSpell), new { id = createdSpell.Id }, createdSpell);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Spell>> GetSpell(int id)
        {
            var spell = await _spellService.GetSpellAsync(id);
            if (spell == null) return NotFound();
            return Ok(spell);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spell>>> GetAllSpells()
        {
            var spells = await _spellService.GetAllSpellsAsync();
            return Ok(spells);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpell(int id, Spell spell)
        {
            var updated = await _spellService.UpdateSpellAsync(id, spell);
            if (!updated) return BadRequest("IDs não correspondem ou magia não encontrada.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpell(int id)
        {
            var deleted = await _spellService.DeleteSpellAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}