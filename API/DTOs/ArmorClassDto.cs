namespace DnDSheetManager.API.DTOs
{
    public class ArmorClassDto
    {
        public int Base { get; set; }
        public int ArmorBonus { get; set; }
        public int ShieldBonus { get; set; }
        public int MagicBonus { get; set; }
        public int MiscBonus { get; set; }
        public int? DexterityModifierCap { get; set; }
        public int Total { get; set; }
    }
}
