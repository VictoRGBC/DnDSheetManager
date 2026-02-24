using System.Text.Json.Serialization;

namespace DnDSheetManager.Domain.Entities
{
    public class CharacterItem
    {
        // Chaves Estrangeiras (Foreign Keys)
        public int CharacterId { get; set; }

        [JsonIgnore]
        public Character? Character { get; set; }

        public int ItemId { get; set; }

        [JsonIgnore]
        public Item? Item { get; set; }

        public int Quantity { get; set; } = 1;
    }
}