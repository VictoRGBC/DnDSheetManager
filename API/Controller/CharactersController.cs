using DnDSheetManager.API.DTOs;
using DnDSheetManager.Application.Services;
using DnDSheetManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DnDSheetManager.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DnDSheetManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly ICombatCalculator _combatCalculator;

        public CharactersController(ICharacterService characterService, ICombatCalculator combatCalculator)
        {
            _characterService = characterService;
            _combatCalculator = combatCalculator;
        }

        // Método helper para pegar UserId do token
        private int GetAuthenticatedUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdClaim ?? "0");
        }

        // GET: api/characters (listar APENAS os do usuário autenticado)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterResponseDto>>> GetAllCharacters()
        {
            var userId = GetAuthenticatedUserId();
            var characters = await _characterService.GetCharactersByUserIdAsync(userId);

            var responseDtos = characters.Select(MapToResponseDto);
            return Ok(responseDtos);
        }

        // POST: api/characters
        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> CreateCharacter(CreateCharacterDto dto)
        {
            var userId = GetAuthenticatedUserId();

            var character = MapCreateDtoToCharacter(dto);
            character.UserId = userId;

            var createdCharacter = await _characterService.CreateCharacterAsync(character);

            var responseDto = MapToResponseDto(createdCharacter);

            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, responseDto);
        }

        private Character MapCreateDtoToCharacter(CreateCharacterDto dto)
        {
            return new Character
            {
                Name = dto.Name,
                Species = dto.Species,
                ClassName = dto.ClassName,
                Level = dto.Level,
                MaxHitPoints = dto.MaxHitPoints,
                CurrentHitPoints = dto.CurrentHitPoints,
                Abilities = new Domain.ValueObjects.AbilityScores
                {
                    Strength = dto.Abilities.Strength,
                    Dexterity = dto.Abilities.Dexterity,
                    Constitution = dto.Abilities.Constitution,
                    Intelligence = dto.Abilities.Intelligence,
                    Wisdom = dto.Abilities.Wisdom,
                    Charisma = dto.Abilities.Charisma
                }
            };
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
                Damage = dto.Damage,
                DamageType = dto.DamageType,
                IsRanged = dto.IsRanged,
                IsFinesse = dto.IsFinesse,
                IsProficient = dto.IsProficient
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

        // PATCH: api/characters/{id}/resources/{resourceId}/consume
        [HttpPatch("{id}/resources/{resourceId}/consume")]
        public async Task<IActionResult> ConsumeResource(int id, int resourceId, [FromBody] CharacterActionDto dto)
        {
            if (dto.Amount <= 0) return BadRequest("A quantidade a consumir deve ser maior que zero.");

            var success = await _characterService.ConsumeResourceAsync(id, resourceId, dto.Amount);
            if (!success) return NotFound("Personagem ou recurso não encontrado.");

            return Ok($"Recurso consumido. Quantidade gasta: {dto.Amount}.");
        }

        // PATCH: api/characters/{id}/resources/{resourceId}/restore
        [HttpPatch("{id}/resources/{resourceId}/restore")]
        public async Task<IActionResult> RestoreResource(int id, int resourceId, [FromBody] CharacterActionDto dto)
        {
            if (dto.Amount <= 0) return BadRequest("A quantidade a recuperar deve ser maior que zero.");

            var success = await _characterService.RestoreResourceAsync(id, resourceId, dto.Amount);
            if (!success) return NotFound("Personagem ou recurso não encontrado.");

            return Ok($"Recurso recuperado. Quantidade restaurada: {dto.Amount}.");
        }

        // POST: api/characters/{id}/spells
        [HttpPost("{id}/spells")]
        public async Task<IActionResult> LearnSpell(int id, [FromBody] LearnSpellDto dto)
        {
            var success = await _characterService.LearnSpellAsync(id, dto.SpellId, dto.IsPrepared);

            if (!success) return NotFound("Personagem não encontrado ou falha ao aprender a magia.");

            return Ok("Magia adicionada ao grimório com sucesso!");
        }

        // POST: api/characters/{id}/spell-slots/{level}/use
        [HttpPost("{id}/spell-slots/{level}/use")]
        public async Task<IActionResult> UseSpellSlot(int id, int level)
        {
            if (level < 1 || level > 9)
                return BadRequest("Nível de magia deve estar entre 1 e 9.");

            var success = await _characterService.UseSpellSlotAsync(id, level);
            if (!success)
                return BadRequest("Personagem não encontrado ou não há espaços de magia disponíveis neste nível.");

            return Ok($"Espaço de magia de nível {level} usado com sucesso!");
        }

        // POST: api/characters/{id}/spell-slots/{level}/restore
        [HttpPost("{id}/spell-slots/{level}/restore")]
        public async Task<IActionResult> RestoreSpellSlot(int id, int level)
        {
            if (level < 1 || level > 9)
                return BadRequest("Nível de magia deve estar entre 1 e 9.");

            var success = await _characterService.RestoreSpellSlotAsync(id, level);
            if (!success)
                return BadRequest("Personagem não encontrado ou nenhum espaço foi usado neste nível.");

            return Ok($"Espaço de magia de nível {level} restaurado!");
        }

        // POST: api/characters/{id}/long-rest
        [HttpPost("{id}/long-rest")]
        public async Task<IActionResult> LongRest(int id)
        {
            var success = await _characterService.LongRestAsync(id);
            if (!success)
                return NotFound("Personagem não encontrado.");

            return Ok("Descanso longo realizado! HP, hit dice e spell slots restaurados.");
        }

        // POST: api/characters/{id}/hit-dice/use
        [HttpPost("{id}/hit-dice/use")]
        public async Task<IActionResult> UseHitDice(int id, [FromBody] CharacterActionDto dto)
        {
            if (dto.Amount <= 0)
                return BadRequest("A quantidade de dados de vida deve ser maior que zero.");

            var success = await _characterService.UseHitDiceAsync(id, dto.Amount);
            if (!success)
                return BadRequest("Personagem não encontrado ou não há dados de vida suficientes.");

            return Ok($"{dto.Amount} dado(s) de vida usado(s)!");
        }

        // POST: api/characters/{id}/features
        [HttpPost("{id}/features")]
        public async Task<IActionResult> AddFeature(int id, [FromBody] CreateFeatureDto dto)
        {
            var feature = new Feature
            {
                Name = dto.Name,
                Description = dto.Description,
                Source = dto.Source,
                UsesPerRest = dto.UsesPerRest,
                UsesRemaining = dto.UsesPerRest,
                RestType = dto.RestType
            };

            var success = await _characterService.AddFeatureAsync(id, feature);
            if (!success)
                return NotFound("Personagem não encontrado.");

            return Ok("Característica adicionada com sucesso!");
        }

        // POST: api/characters/{id}/features/{featureId}/use
        [HttpPost("{id}/features/{featureId}/use")]
        public async Task<IActionResult> UseFeature(int id, int featureId)
        {
            var success = await _characterService.UseFeatureAsync(id, featureId);
            if (!success)
                return BadRequest("Personagem ou característica não encontrada, ou usos esgotados.");

            return Ok("Característica usada!");
        }

        // POST: api/characters/{id}/short-rest
        [HttpPost("{id}/short-rest")]
        public async Task<IActionResult> ShortRest(int id)
        {
            var success = await _characterService.ShortRestAsync(id);
            if (!success)
                return NotFound("Personagem não encontrado.");

            return Ok("Descanso curto realizado! Features de descanso curto restauradas.");
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
                Speed = character.Speed,

                Background = character.Background,
                Alignment = character.Alignment,
                PersonalityTraits = character.PersonalityTraits,
                Ideals = character.Ideals,
                Bonds = character.Bonds,
                Flaws = character.Flaws,
                HasInspiration = character.HasInspiration,
                ExperiencePoints = character.ExperiencePoints,

                HitDice = new HitDiceDto
                {
                    Type = character.HitDice,
                    Total = character.TotalHitDice,
                    Used = character.HitDiceUsed
                },

                ProficiencyBonus = character.ProficiencyBonus,
                Initiative = character.Initiative,
                PassivePerception = character.PassivePerception,
                BaseArmorClass = character.BaseArmorClass,

                IntSpellSaveDC = character.GetSpellSaveDC(character.Abilities.IntelligenceModifier),
                WisSpellSaveDC = character.GetSpellSaveDC(character.Abilities.WisdomModifier),
                ChaSpellSaveDC = character.GetSpellSaveDC(character.Abilities.CharismaModifier),

                Abilities = new AbilityScoresDto
                {
                    Strength = character.Abilities.Strength,
                    StrengthModifier = character.Abilities.StrengthModifier,
                    Dexterity = character.Abilities.Dexterity,
                    DexterityModifier = character.Abilities.DexterityModifier,
                    Constitution = character.Abilities.Constitution,
                    ConstitutionModifier = character.Abilities.ConstitutionModifier,
                    Intelligence = character.Abilities.Intelligence,
                    IntelligenceModifier = character.Abilities.IntelligenceModifier,
                    Wisdom = character.Abilities.Wisdom,
                    WisdomModifier = character.Abilities.WisdomModifier,
                    Charisma = character.Abilities.Charisma,
                    CharismaModifier = character.Abilities.CharismaModifier
                },

                SavingThrows = new SavingThrowsDto
                {
                    Strength = character.GetSavingThrowBonus("Strength"),
                    Dexterity = character.GetSavingThrowBonus("Dexterity"),
                    Constitution = character.GetSavingThrowBonus("Constitution"),
                    Intelligence = character.GetSavingThrowBonus("Intelligence"),
                    Wisdom = character.GetSavingThrowBonus("Wisdom"),
                    Charisma = character.GetSavingThrowBonus("Charisma"),
                    StrengthProficiency = character.SavingThrows.StrengthProficiency,
                    DexterityProficiency = character.SavingThrows.DexterityProficiency,
                    ConstitutionProficiency = character.SavingThrows.ConstitutionProficiency,
                    IntelligenceProficiency = character.SavingThrows.IntelligenceProficiency,
                    WisdomProficiency = character.SavingThrows.WisdomProficiency,
                    CharismaProficiency = character.SavingThrows.CharismaProficiency
                },

                SpellSlots = new SpellSlotsDto
                {
                    Level1 = new SpellSlotLevelDto { Total = character.SpellSlots.Level1Total, Used = character.SpellSlots.Level1Used },
                    Level2 = new SpellSlotLevelDto { Total = character.SpellSlots.Level2Total, Used = character.SpellSlots.Level2Used },
                    Level3 = new SpellSlotLevelDto { Total = character.SpellSlots.Level3Total, Used = character.SpellSlots.Level3Used },
                    Level4 = new SpellSlotLevelDto { Total = character.SpellSlots.Level4Total, Used = character.SpellSlots.Level4Used },
                    Level5 = new SpellSlotLevelDto { Total = character.SpellSlots.Level5Total, Used = character.SpellSlots.Level5Used },
                    Level6 = new SpellSlotLevelDto { Total = character.SpellSlots.Level6Total, Used = character.SpellSlots.Level6Used },
                    Level7 = new SpellSlotLevelDto { Total = character.SpellSlots.Level7Total, Used = character.SpellSlots.Level7Used },
                    Level8 = new SpellSlotLevelDto { Total = character.SpellSlots.Level8Total, Used = character.SpellSlots.Level8Used },
                    Level9 = new SpellSlotLevelDto { Total = character.SpellSlots.Level9Total, Used = character.SpellSlots.Level9Used }
                },

                Skills = new SkillsDto
                {
                    Acrobatics = character.Skills.Acrobatics,
                    AnimalHandling = character.Skills.AnimalHandling,
                    Arcana = character.Skills.Arcana,
                    Athletics = character.Skills.Athletics,
                    Deception = character.Skills.Deception,
                    History = character.Skills.History,
                    Insight = character.Skills.Insight,
                    Intimidation = character.Skills.Intimidation,
                    Investigation = character.Skills.Investigation,
                    Medicine = character.Skills.Medicine,
                    Nature = character.Skills.Nature,
                    Perception = character.Skills.Perception,
                    Performance = character.Skills.Performance,
                    Persuasion = character.Skills.Persuasion,
                    Religion = character.Skills.Religion,
                    SleightOfHand = character.Skills.SleightOfHand,
                    Stealth = character.Skills.Stealth,
                    Survival = character.Skills.Survival,
                    AcrobaticsExpertise = character.Skills.AcrobaticsExpertise,
                    AnimalHandlingExpertise = character.Skills.AnimalHandlingExpertise,
                    ArcanaExpertise = character.Skills.ArcanaExpertise,
                    AthleticsExpertise = character.Skills.AthleticsExpertise,
                    DeceptionExpertise = character.Skills.DeceptionExpertise,
                    HistoryExpertise = character.Skills.HistoryExpertise,
                    InsightExpertise = character.Skills.InsightExpertise,
                    IntimidationExpertise = character.Skills.IntimidationExpertise,
                    InvestigationExpertise = character.Skills.InvestigationExpertise,
                    MedicineExpertise = character.Skills.MedicineExpertise,
                    NatureExpertise = character.Skills.NatureExpertise,
                    PerceptionExpertise = character.Skills.PerceptionExpertise,
                    PerformanceExpertise = character.Skills.PerformanceExpertise,
                    PersuasionExpertise = character.Skills.PersuasionExpertise,
                    ReligionExpertise = character.Skills.ReligionExpertise,
                    SleightOfHandExpertise = character.Skills.SleightOfHandExpertise,
                    StealthExpertise = character.Skills.StealthExpertise,
                    SurvivalExpertise = character.Skills.SurvivalExpertise
                },

                ArmorClass = new ArmorClassDto
                {
                    Base = character.AC.Base,
                    ArmorBonus = character.AC.ArmorBonus,
                    ShieldBonus = character.AC.ShieldBonus,
                    MagicBonus = character.AC.MagicBonus,
                    MiscBonus = character.AC.MiscBonus,
                    DexterityModifierCap = character.AC.DexterityModifierCap,
                    Total = character.TotalArmorClass
                },

                Conditions = new ConditionsDto
                {
                    Blinded = character.Conditions.Blinded,
                    Charmed = character.Conditions.Charmed,
                    Deafened = character.Conditions.Deafened,
                    Frightened = character.Conditions.Frightened,
                    Grappled = character.Conditions.Grappled,
                    Incapacitated = character.Conditions.Incapacitated,
                    Invisible = character.Conditions.Invisible,
                    Paralyzed = character.Conditions.Paralyzed,
                    Petrified = character.Conditions.Petrified,
                    Poisoned = character.Conditions.Poisoned,
                    Prone = character.Conditions.Prone,
                    Restrained = character.Conditions.Restrained,
                    Stunned = character.Conditions.Stunned,
                    Unconscious = character.Conditions.Unconscious,
                    Exhaustion = character.Conditions.Exhaustion,
                    ExhaustionLevel = character.Conditions.ExhaustionLevel
                },

                DamageResistances = new DamageResistancesDto
                {
                    Resistances = character.DamageResistances.Resistances,
                    Immunities = character.DamageResistances.Immunities,
                    Vulnerabilities = character.DamageResistances.Vulnerabilities
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
                    Damage = a.Damage,
                    DamageType = a.DamageType,
                    IsRanged = a.IsRanged,
                    IsFinesse = a.IsFinesse,
                    IsProficient = a.IsProficient,

                    AttackBonus = a.IsRanged
                        ? _combatCalculator.CalculateRangedAttackBonus(character, a.IsProficient)
                        : _combatCalculator.CalculateMeleeAttackBonus(character, a.IsFinesse, a.IsProficient)

                }).ToList() ?? new List<AttackResponseDto>(),

                ClassResources = character.ClassResources?.Select(r => new ResourceResponseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    MaxValue = r.MaxValue,
                    CurrentValue = r.CurrentValue
                }).ToList() ?? new List<ResourceResponseDto>(),

                Spells = character.Spells?.Select(s => new SpellResponseDto
                {
                    SpellId = s.SpellId,
                    Name = s.Spell?.Name ?? "Magia Desconhecida",
                    Level = s.Spell?.Level ?? 0,
                    School = s.Spell?.School ?? string.Empty,
                    IsPrepared = s.IsPrepared
                }).ToList() ?? new List<SpellResponseDto>(),

                Features = character.Features?.Select(f => new FeatureDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    Source = f.Source,
                    UsesPerRest = f.UsesPerRest,
                    UsesRemaining = f.UsesRemaining,
                    RestType = f.RestType
                }).ToList() ?? new List<FeatureDto>()
            };
        }
    }
}