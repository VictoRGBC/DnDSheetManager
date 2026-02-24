using System.Text.Json.Serialization;

namespace DnDSheetManager.Domain.Entities
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } 
        public string School { get; set; } = string.Empty; 
        public string CastingTime { get; set; } = string.Empty; 
        public string Range { get; set; } = string.Empty; 
        public string Components { get; set; } = string.Empty; 
        public string Duration { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Propriedade de navegação
        [JsonIgnore]
        public ICollection<CharacterSpell> CharacterSpells { get; set; } = new List<CharacterSpell>();
    }
}