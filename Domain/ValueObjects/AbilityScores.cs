namespace DnDSheetManager.Domain.ValueObjects
{
    public class AbilityScores
    {
        // Força
        public int Strength { get; set; } = 10;
        public int StrengthModifier => (int)Math.Floor((Strength - 10) / 2.0);

        // Destreza
        public int Dexterity { get; set; } = 10;
        public int DexterityModifier => (int)Math.Floor((Dexterity - 10) / 2.0);

        // Constituição
        public int Constitution { get; set; } = 10;
        public int ConstitutionModifier => (int)Math.Floor((Constitution - 10) / 2.0);

        // Inteligência
        public int Intelligence { get; set; } = 10;
        public int IntelligenceModifier => (int)Math.Floor((Intelligence - 10) / 2.0);

        // Sabedoria
        public int Wisdom { get; set; } = 10;
        public int WisdomModifier => (int)Math.Floor((Wisdom - 10) / 2.0);

        // Carisma
        public int Charisma { get; set; } = 10;
        public int CharismaModifier => (int)Math.Floor((Charisma - 10) / 2.0);
    }
}