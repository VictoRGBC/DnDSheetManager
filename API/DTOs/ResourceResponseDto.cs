namespace DnDSheetManager.API.DTOs
{
    public class ResourceResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
    }
}