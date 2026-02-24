namespace DnDSheetManager.API.DTOs
{
    public class AttackResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AttackBonus { get; set; }
        public string Damage { get; set; } = string.Empty;
        public string DamageType { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
    }
}