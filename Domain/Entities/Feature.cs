using System.Text.Json.Serialization;

namespace DnDSheetManager.Domain.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        
        [JsonIgnore]
        public Character? Character { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // "Racial", "Class", "Feat", "Background"
        public string Source { get; set; } = string.Empty;
        
        // null = passivo (sempre ativo), número = usa por descanso
        public int? UsesPerRest { get; set; }
        public int? UsesRemaining { get; set; }

        // "Short" ou "Long" - quando restaura os usos
        public string? RestType { get; set; }

        public void Use()
        {
            if (UsesRemaining.HasValue && UsesRemaining > 0)
            {
                UsesRemaining--;
            }
        }

        public void RestoreUses()
        {
            if (UsesPerRest.HasValue)
            {
                UsesRemaining = UsesPerRest;
            }
        }
    }
}
