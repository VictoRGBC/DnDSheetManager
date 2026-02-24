using System.Text.Json.Serialization;

namespace DnDSheetManager.Domain.Entities
{
    public class CharacterResource
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }

        [JsonIgnore]
        public Character? Character { get; set; }

        public string Name { get; set; } = string.Empty;
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }


        public void Consume(int amount)
        {
            CurrentValue -= amount;
            if (CurrentValue < 0) CurrentValue = 0;
        }

        public void Restore(int amount)
        {
            CurrentValue += amount;
            if (CurrentValue > MaxValue) CurrentValue = MaxValue;
        }
    }
}