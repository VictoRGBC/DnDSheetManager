namespace DnDSheetManager.API.DTOs
{
    public class ConditionsDto
    {
        public bool Blinded { get; set; }
        public bool Charmed { get; set; }
        public bool Deafened { get; set; }
        public bool Frightened { get; set; }
        public bool Grappled { get; set; }
        public bool Incapacitated { get; set; }
        public bool Invisible { get; set; }
        public bool Paralyzed { get; set; }
        public bool Petrified { get; set; }
        public bool Poisoned { get; set; }
        public bool Prone { get; set; }
        public bool Restrained { get; set; }
        public bool Stunned { get; set; }
        public bool Unconscious { get; set; }
        public bool Exhaustion { get; set; }
        public int ExhaustionLevel { get; set; }
    }
}
