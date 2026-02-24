using DnDSheetManager.Domain.Entities;

namespace DnDSheetManager.Domain.Services
{
    public interface ICombatCalculator
    {
        int CalculateMeleeAttackBonus(Character character, bool isFinesse, bool hasProficiency);
        int CalculateRangedAttackBonus(Character character, bool hasProficiency);
        int CalculateSpellAttackBonus(Character character, int spellcastingModifier);
    }
}