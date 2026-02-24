using DnDSheetManager.Domain.ValueObjects;
namespace DnDSheetManager.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        public AbilityScores Abilities { get; set; } = new AbilityScores();
        public Coins Wealth { get; set; } = new Coins();
        public Skills Skills { get; set; } = new Skills();

        public ICollection<CharacterItem> Inventory { get; set; } = new List<CharacterItem>();

        public ICollection<Attack> Attacks { get; set; } = new List<Attack>();
        public ICollection<CharacterResource> ClassResources { get; set; } = new List<CharacterResource>();

        public int GetModifier(int attributeScore)
        {
            return (int)Math.Floor((attributeScore - 10) / 2.0);
        }

        public void TakeDamage(int damageAmount)
        {
            CurrentHitPoints -= damageAmount;
            if (CurrentHitPoints < 0) CurrentHitPoints = 0;
        }

        public void Heal(int healAmount)
        {
            CurrentHitPoints += healAmount;
            if (CurrentHitPoints > MaxHitPoints) CurrentHitPoints = MaxHitPoints;
        }
    }
}