namespace DnDSheetManager.API.DTOs
{
    public class SpellResponseDto
    {
        public int SpellId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string School { get; set; } = string.Empty;
        public bool IsPrepared { get; set; }
    }
}