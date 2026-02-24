namespace DnDSheetManager.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Weight { get; set; } // Peso do item
        public int ValueInGold { get; set; } // Valor em peças de ouro

        // Propriedade de navegação para a tabela intermediária
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<CharacterItem> CharacterItems { get; set; } = new List<CharacterItem>();
    }
}