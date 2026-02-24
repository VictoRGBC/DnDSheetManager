using System.Text.Json.Serialization;

namespace DnDSheetManager.Domain.Entities
{
    public class CharacterSpell
    {
        public int CharacterId { get; set; }

        [JsonIgnore]
        public Character? Character { get; set; }

        public int SpellId { get; set; }

        [JsonIgnore]
        public Spell? Spell { get; set; }

        public bool IsPrepared { get; set; } = false;
    }
}