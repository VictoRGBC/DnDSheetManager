namespace DnDSheetManager.Domain.Entities
{
    public class Character
    {
        // Identificador único (Primary Key no banco)
        public int Id { get; set; }

        // Informações Básicas
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; } = 1;

        // Pontos de Vida (HP)
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        // Atributos Base de D&D
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        // Navegação para o Inventário
        public ICollection<CharacterItem> Inventory { get; set; } = new List<CharacterItem>();

        // Método simples para exemplificar comportamento na entidade
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

        // Método encapsulado com a regra oficial de D&D para calcular modificadores
        public int GetModifier(int attributeScore)
        {
            return (int)Math.Floor((attributeScore - 10) / 2.0);
        }
    }
}