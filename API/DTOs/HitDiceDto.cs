namespace DnDSheetManager.API.DTOs
{
    public class HitDiceDto
    {
        public string Type { get; set; } = "1d8"; // Ex: "3d10"
        public int Total { get; set; }
        public int Used { get; set; }
        public int Available => Math.Max(0, Total - Used);
    }
}
