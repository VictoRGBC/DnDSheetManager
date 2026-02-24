namespace DnDSheetManager.Domain.Entities
{
    public class Attack
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character? Character { get; set; }

        public string Name { get; set; } = string.Empty;
        public int AttackBonus { get; set; }
        public string Damage { get; set; } = string.Empty;
        public string DamageType { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
    }
}