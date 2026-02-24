namespace DnDSheetManager.API.DTOs
{
    public class CreateResourceDto
    {
        public string Name { get; set; } = string.Empty;
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
    }
}