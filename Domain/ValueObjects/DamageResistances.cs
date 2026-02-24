namespace DnDSheetManager.Domain.ValueObjects
{
    public class DamageResistances
    {
        public List<string> Resistances { get; set; } = new();
        public List<string> Immunities { get; set; } = new();
        public List<string> Vulnerabilities { get; set; } = new();

        public int CalculateDamageReceived(int rawDamage, string damageType)
        {
            if (Immunities.Contains(damageType))
                return 0;
            
            if (Resistances.Contains(damageType))
                return rawDamage / 2;
            
            if (Vulnerabilities.Contains(damageType))
                return rawDamage * 2;
            
            return rawDamage;
        }

        public void AddResistance(string damageType)
        {
            if (!Resistances.Contains(damageType))
                Resistances.Add(damageType);
        }

        public void AddImmunity(string damageType)
        {
            if (!Immunities.Contains(damageType))
                Immunities.Add(damageType);
        }

        public void AddVulnerability(string damageType)
        {
            if (!Vulnerabilities.Contains(damageType))
                Vulnerabilities.Add(damageType);
        }
    }
}
