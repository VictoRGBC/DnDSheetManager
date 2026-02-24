using DnDSheetManager.Domain.ValueObjects;
namespace DnDSheetManager.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; } = 1;

        // --- PONTOS DE VIDA E DADOS DE VIDA ---
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public string HitDice { get; set; } = "1d8";
        public int HitDiceUsed { get; set; } = 0;

        // Propriedades calculadas para Hit Dice
        public int TotalHitDice => Level;
        public int AvailableHitDice => Math.Max(0, TotalHitDice - HitDiceUsed);

        // --- VELOCIDADE ---
        public int Speed { get; set; } = 30;

        // --- BACKGROUND E PERSONALIDADE ---
        public string Background { get; set; } = string.Empty;
        public string Alignment { get; set; } = "Neutro";
        public string PersonalityTraits { get; set; } = string.Empty;
        public string Ideals { get; set; } = string.Empty;
        public string Bonds { get; set; } = string.Empty;
        public string Flaws { get; set; } = string.Empty;

        // INSPIRAÇÃO
        public bool HasInspiration { get; set; } = false;

        // EXPERIÊNCIA
        public int ExperiencePoints { get; set; } = 0;

        // --- REGRAS DINÂMICAS DE D&D 5.5 ---

        // 2. Bônus de Proficiência
        public int ProficiencyBonus => (int)Math.Ceiling(Level / 4.0) + 1;

        // 7. Iniciativa
        public int Initiative => Abilities.DexterityModifier;

        // 8. Spell Save DC
        public int GetSpellSaveDC(int spellcastingModifier)
        {
            return 8 + ProficiencyBonus + spellcastingModifier;
        }

        // 17. Percepção Passiva (10 + Mod. Sabedoria + Proficiência se tiver a Skill)
        public int PassivePerception => 10 + Abilities.WisdomModifier + (Skills.Perception ? ProficiencyBonus : 0);

        // 4. Classe de Armadura Base (Sem armadura)
        public int BaseArmorClass => 10 + Abilities.DexterityModifier;

        // --- TESTES DE RESISTÊNCIA (SAVING THROWS) ---
        public int GetSavingThrowBonus(string abilityName)
        {
            var modifier = abilityName switch
            {
                "Strength" => Abilities.StrengthModifier,
                "Dexterity" => Abilities.DexterityModifier,
                "Constitution" => Abilities.ConstitutionModifier,
                "Intelligence" => Abilities.IntelligenceModifier,
                "Wisdom" => Abilities.WisdomModifier,
                "Charisma" => Abilities.CharismaModifier,
                _ => 0
            };

            var proficient = abilityName switch
            {
                "Strength" => SavingThrows.StrengthProficiency,
                "Dexterity" => SavingThrows.DexterityProficiency,
                "Constitution" => SavingThrows.ConstitutionProficiency,
                "Intelligence" => SavingThrows.IntelligenceProficiency,
                "Wisdom" => SavingThrows.WisdomProficiency,
                "Charisma" => SavingThrows.CharismaProficiency,
                _ => false
            };

            return modifier + (proficient ? ProficiencyBonus : 0);
        }

        // Método calculador geral de Skills e Saving Throws
        public int GetSkillOrSaveBonus(int abilityModifier, bool hasProficiency, bool hasExpertise = false)
        {
            int total = abilityModifier;
            if (hasProficiency) total += ProficiencyBonus;
            if (hasExpertise) total += ProficiencyBonus;

            return total;
        }

        public AbilityScores Abilities { get; set; } = new AbilityScores();
        public SavingThrows SavingThrows { get; set; } = new SavingThrows();
        public Coins Wealth { get; set; } = new Coins();
        public Skills Skills { get; set; } = new Skills();
        public SpellSlots SpellSlots { get; set; } = new SpellSlots();
        public ArmorClass AC { get; set; } = new ArmorClass();
        public Conditions Conditions { get; set; } = new Conditions();
        public DamageResistances DamageResistances { get; set; } = new DamageResistances();

        // Propriedade calculada para AC total
        public int TotalArmorClass => AC.GetTotal(Abilities.DexterityModifier);

        public ICollection<CharacterItem> Inventory { get; set; } = new List<CharacterItem>();

        public ICollection<Attack> Attacks { get; set; } = new List<Attack>();
        public ICollection<CharacterResource> ClassResources { get; set; } = new List<CharacterResource>();

        public ICollection<CharacterSpell> Spells { get; set; } = new List<CharacterSpell>();
        public ICollection<Feature> Features { get; set; } = new List<Feature>();

        public int GetModifier(int attributeScore)
        {
            return (int)Math.Floor((attributeScore - 10) / 2.0);
        }

        public void TakeDamage(int damageAmount)
        {
            CurrentHitPoints -= damageAmount;
            if (CurrentHitPoints < 0) CurrentHitPoints = 0;
        }

        public void Heal(int healAmount)
        {
            CurrentHitPoints += healAmount;
            if (CurrentHitPoints > MaxHitPoints) CurrentHitPoints = MaxHitPoints;
        }

        public void UseHitDice(int diceCount = 1)
        {
            if (AvailableHitDice >= diceCount)
            {
                HitDiceUsed += diceCount;
            }
        }

        public void LongRest()
        {
            CurrentHitPoints = MaxHitPoints;

            int hitDiceToRecover = Math.Max(1, Level / 2);
            HitDiceUsed = Math.Max(0, HitDiceUsed - hitDiceToRecover);

            SpellSlots.LongRest();
        }

        public void ShortRest()
        {
            // Short Rest não restaura automaticamente HP
            // Apenas permite usar Hit Dice para curar
            // Alguns recursos podem ser restaurados aqui (depende da classe)
        }
    }
}