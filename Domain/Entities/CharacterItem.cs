namespace DnDSheetManager.Domain.Entities
{
    public class CharacterItem
    {
        // Chaves Estrangeiras (Foreign Keys)
        public int CharacterId { get; set; }
        public Character? Character { get; set; }

        public int ItemId { get; set; }
        public Item? Item { get; set; }

        public int Quantity { get; set; } = 1;
    }
}