using DnDSheetManager.Domain.Entities;

namespace DnDSheetManager.Domain.Services
{
    public class CombatCalculator : ICombatCalculator
    {
        // 9.1 e 9.2 Corpo-a-corpo e Finesse
        public int CalculateMeleeAttackBonus(Character character, bool isFinesse, bool hasProficiency)
        {
            int baseModifier = character.Abilities.StrengthModifier;

            // Se for Finesse (Acuidade), usa o maior entre Força e Destreza
            if (isFinesse)
            {
                baseModifier = Math.Max(character.Abilities.StrengthModifier, character.Abilities.DexterityModifier);
            }

            int proficiencyBonus = hasProficiency ? character.ProficiencyBonus : 0;

            return baseModifier + proficiencyBonus;
        }

        // 9.3 À distância
        public int CalculateRangedAttackBonus(Character character, bool hasProficiency)
        {
            int proficiencyBonus = hasProficiency ? character.ProficiencyBonus : 0;
            return character.Abilities.DexterityModifier + proficiencyBonus;
        }

        // 8.2 Bônus de Ataque Mágico
        public int CalculateSpellAttackBonus(Character character, int spellcastingModifier)
        {
            // O bónus de ataque mágico tem sempre proficiência
            return character.ProficiencyBonus + spellcastingModifier;
        }
    }
}