namespace DnDSheetManager.Domain.Entities
{
    public class CharacterResource
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character? Character { get; set; }

        public string Name { get; set; } = string.Empty;
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
    }
}