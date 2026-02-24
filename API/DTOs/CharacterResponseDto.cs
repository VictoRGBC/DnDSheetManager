
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

        public AbilityScoresDto Abilities { get; set; } = new AbilityScoresDto();
        public CoinsDto Wealth { get; set; } = new CoinsDto();
        public SkillsDto Skills { get; set; } = new SkillsDto();

        public List<InventoryItemDto> Inventory { get; set; } = new List<InventoryItemDto>();

        public List<AttackResponseDto> Attacks { get; set; } = new List<AttackResponseDto>();
        public List<ResourceResponseDto> ClassResources { get; set; } = new List<ResourceResponseDto>();
    }
}