namespace DnDSheetManager.API.DTOs
{
    public class CharacterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }

        // Atributos
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        // Modificadores calculados
        public int StrengthModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int ConstitutionModifier { get; set; }
        public int IntelligenceModifier { get; set; }
        public int WisdomModifier { get; set; }
        public int CharismaModifier { get; set; }

        // A lista limpa de itens
        public List<InventoryItemDto> Inventory { get; set; } = new List<InventoryItemDto>();
    }
}