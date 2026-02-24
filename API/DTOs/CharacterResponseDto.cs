
namespace DnDSheetManager.API.DTOs
{
    public class CharacterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Speed { get; set; }

        // Background & Personalidade
        public string Background { get; set; } = string.Empty;
        public string Alignment { get; set; } = string.Empty;
        public string PersonalityTraits { get; set; } = string.Empty;
        public string Ideals { get; set; } = string.Empty;
        public string Bonds { get; set; } = string.Empty;
        public string Flaws { get; set; } = string.Empty;
        public bool HasInspiration { get; set; }
        public int ExperiencePoints { get; set; }

        // Hit Dice
        public HitDiceDto HitDice { get; set; } = new();

        // --- DADOS CALCULADOS DINAMICAMENTE PELO DOMÍNIO ---
        public int ProficiencyBonus { get; set; }
        public int Initiative { get; set; }
        public int PassivePerception { get; set; }
        public int BaseArmorClass { get; set; }

        // CDs de Magia para cada atributo mental
        public int IntSpellSaveDC { get; set; }
        public int WisSpellSaveDC { get; set; }
        public int ChaSpellSaveDC { get; set; }

        public AbilityScoresDto Abilities { get; set; } = new AbilityScoresDto();
        public SavingThrowsDto SavingThrows { get; set; } = new SavingThrowsDto();
        public CoinsDto Wealth { get; set; } = new CoinsDto();
        public SkillsDto Skills { get; set; } = new SkillsDto();
        public SpellSlotsDto SpellSlots { get; set; } = new SpellSlotsDto();
        public ArmorClassDto ArmorClass { get; set; } = new ArmorClassDto();
        public ConditionsDto Conditions { get; set; } = new ConditionsDto();
        public DamageResistancesDto DamageResistances { get; set; } = new DamageResistancesDto();

        public List<InventoryItemDto> Inventory { get; set; } = new List<InventoryItemDto>();

        public List<AttackResponseDto> Attacks { get; set; } = new List<AttackResponseDto>();
        public List<ResourceResponseDto> ClassResources { get; set; } = new List<ResourceResponseDto>();

        public List<SpellResponseDto> Spells { get; set; } = new List<SpellResponseDto>();
        public List<FeatureDto> Features { get; set; } = new List<FeatureDto>();
    }
}