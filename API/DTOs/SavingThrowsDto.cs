namespace DnDSheetManager.API.DTOs
{
    public class SavingThrowsDto
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public bool StrengthProficiency { get; set; }
        public bool DexterityProficiency { get; set; }
        public bool ConstitutionProficiency { get; set; }
        public bool IntelligenceProficiency { get; set; }
        public bool WisdomProficiency { get; set; }
        public bool CharismaProficiency { get; set; }
    }
}
