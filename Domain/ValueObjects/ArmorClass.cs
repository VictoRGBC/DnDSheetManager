namespace DnDSheetManager.Domain.ValueObjects
{
    public class ArmorClass
    {
        public int Base { get; set; } = 10;
        public int ArmorBonus { get; set; } = 0;
        public int ShieldBonus { get; set; } = 0;
        public int MagicBonus { get; set; } = 0;
        public int MiscBonus { get; set; } = 0;
        
        // Algumas armaduras limitam o bônus de Destreza (ex: armadura pesada = 0, média = 2)
        public int? DexterityModifierCap { get; set; } = null;

        public int GetTotal(int dexModifier)
        {
            int dexBonus = DexterityModifierCap.HasValue 
                ? Math.Min(dexModifier, DexterityModifierCap.Value)
                : dexModifier;

            return Base + ArmorBonus + ShieldBonus + dexBonus + MagicBonus + MiscBonus;
        }
    }
}
