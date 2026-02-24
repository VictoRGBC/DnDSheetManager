namespace DnDSheetManager.Domain.Entities
{
    public class Attack
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character? Character { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Damage { get; set; } = string.Empty;
        public string DamageType { get; set; } = string.Empty;

        // Propriedades essenciais para a calculadora saber o que fazer
        public bool IsRanged { get; set; }
        public bool IsFinesse { get; set; }
        public bool IsProficient { get; set; }
    }
}