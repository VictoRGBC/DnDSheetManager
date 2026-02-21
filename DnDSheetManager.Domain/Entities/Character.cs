
namespace Domain.Entities
{
    public class Character
    {
        // Identificador único (PK)
        public int Id { get; set; }

        // Informações básicas
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; } = 1;

        // Pontos de vida (PV)
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        // Atributos base de D&D
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        // Método simples para exemplificar o comportamento na entidade
        public void TakeDamage(int damageAmount)
        {
            CurrentHitPoints -= damageAmount;
            if (CurrentHitPoints < 0)
                CurrentHitPoints = 0;
        }

        public void Heal(int healAmount)
        {
            CurrentHitPoints += healAmount;
            if (CurrentHitPoints > MaxHitPoints)
                CurrentHitPoints = MaxHitPoints;
        }
    }
}
