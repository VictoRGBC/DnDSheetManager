namespace DnDSheetManager.API.DTOs
{
    public class SpellSlotsDto
    {
        public SpellSlotLevelDto Level1 { get; set; } = new();
        public SpellSlotLevelDto Level2 { get; set; } = new();
        public SpellSlotLevelDto Level3 { get; set; } = new();
        public SpellSlotLevelDto Level4 { get; set; } = new();
        public SpellSlotLevelDto Level5 { get; set; } = new();
        public SpellSlotLevelDto Level6 { get; set; } = new();
        public SpellSlotLevelDto Level7 { get; set; } = new();
        public SpellSlotLevelDto Level8 { get; set; } = new();
        public SpellSlotLevelDto Level9 { get; set; } = new();
    }

    public class SpellSlotLevelDto
    {
        public int Total { get; set; }
        public int Used { get; set; }
        public int Available => Math.Max(0, Total - Used);
    }
}
