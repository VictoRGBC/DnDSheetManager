namespace DnDSheetManager.Domain.ValueObjects
{
    public class Conditions
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
        public int ExhaustionLevel { get; set; } = 0; // 0-6

        public bool HasAnyCondition()
        {
            return Blinded || Charmed || Deafened || Frightened || Grappled ||
                   Incapacitated || Invisible || Paralyzed || Petrified || Poisoned ||
                   Prone || Restrained || Stunned || Unconscious || Exhaustion;
        }

        public void ClearAll()
        {
            Blinded = false;
            Charmed = false;
            Deafened = false;
            Frightened = false;
            Grappled = false;
            Incapacitated = false;
            Invisible = false;
            Paralyzed = false;
            Petrified = false;
            Poisoned = false;
            Prone = false;
            Restrained = false;
            Stunned = false;
            Unconscious = false;
            Exhaustion = false;
            ExhaustionLevel = 0;
        }
    }
}
