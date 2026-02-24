namespace DnDSheetManager.API.DTOs
{
    public class DamageResistancesDto
    {
        public List<string> Resistances { get; set; } = new();
        public List<string> Immunities { get; set; } = new();
        public List<string> Vulnerabilities { get; set; } = new();
    }
}
