using DnDSheetManager.Domain.Entities;
using DnDSheetManager.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.Domain
{
    public class CharacterTests
    {
        [Fact]
        public void Character_ProficiencyBonus_ShouldBeCalculatedCorrectly()
        {
            // Arrange & Act
            var level1 = new Character { Level = 1 };
            var level5 = new Character { Level = 5 };
            var level9 = new Character { Level = 9 };
            var level17 = new Character { Level = 17 };

            // Assert
            level1.ProficiencyBonus.Should().Be(2);
            level5.ProficiencyBonus.Should().Be(3);
            level9.ProficiencyBonus.Should().Be(4);
            level17.ProficiencyBonus.Should().Be(6);
        }

        [Fact]
        public void Character_Initiative_ShouldEqualDexterityModifier()
        {
            // Arrange
            var character = new Character
            {
                Abilities = new AbilityScores { Dexterity = 16 } // +3
            };

            // Act
            var initiative = character.Initiative;

            // Assert
            initiative.Should().Be(3);
        }

        [Fact]
        public void Character_BaseArmorClass_ShouldBe10PlusDexModifier()
        {
            // Arrange
            var character = new Character
            {
                Abilities = new AbilityScores { Dexterity = 14 } // +2
            };

            // Act
            var ac = character.BaseArmorClass;

            // Assert
            ac.Should().Be(12); // 10 + 2
        }

        [Fact]
        public void Character_TakeDamage_ShouldReduceHP()
        {
            // Arrange
            var character = new Character
            {
                MaxHitPoints = 30,
                CurrentHitPoints = 30
            };

            // Act
            character.TakeDamage(10);

            // Assert
            character.CurrentHitPoints.Should().Be(20);
        }

        [Fact]
        public void Character_TakeDamage_ShouldNotGoBelowZero()
        {
            // Arrange
            var character = new Character
            {
                MaxHitPoints = 30,
                CurrentHitPoints = 5
            };

            // Act
            character.TakeDamage(10);

            // Assert
            character.CurrentHitPoints.Should().Be(0);
        }

        [Fact]
        public void Character_Heal_ShouldIncreaseHP()
        {
            // Arrange
            var character = new Character
            {
                MaxHitPoints = 30,
                CurrentHitPoints = 10
            };

            // Act
            character.Heal(15);

            // Assert
            character.CurrentHitPoints.Should().Be(25);
        }

        [Fact]
        public void Character_Heal_ShouldNotExceedMaxHP()
        {
            // Arrange
            var character = new Character
            {
                MaxHitPoints = 30,
                CurrentHitPoints = 25
            };

            // Act
            character.Heal(10);

            // Assert
            character.CurrentHitPoints.Should().Be(30);
        }

        [Fact]
        public void Character_GetSavingThrowBonus_WithProficiency_ShouldAddBonus()
        {
            // Arrange
            var character = new Character
            {
                Level = 5, // Prof +3
                Abilities = new AbilityScores { Strength = 16 }, // +3
                SavingThrows = new SavingThrows { StrengthProficiency = true }
            };

            // Act
            var bonus = character.GetSavingThrowBonus("Strength");

            // Assert
            bonus.Should().Be(6); // +3 (ability) + 3 (prof)
        }

        [Fact]
        public void Character_GetSavingThrowBonus_WithoutProficiency_ShouldOnlyUseAbility()
        {
            // Arrange
            var character = new Character
            {
                Level = 5,
                Abilities = new AbilityScores { Dexterity = 14 }, // +2
                SavingThrows = new SavingThrows { DexterityProficiency = false }
            };

            // Act
            var bonus = character.GetSavingThrowBonus("Dexterity");

            // Assert
            bonus.Should().Be(2); // +2 (ability)
        }

        [Fact]
        public void Character_UseHitDice_ShouldIncreaseUsedCount()
        {
            // Arrange
            var character = new Character
            {
                Level = 5,
                HitDiceUsed = 0
            };

            // Act
            character.UseHitDice(2);

            // Assert
            character.HitDiceUsed.Should().Be(2);
            character.AvailableHitDice.Should().Be(3);
        }

        [Fact]
        public void Character_LongRest_ShouldRestoreHP()
        {
            // Arrange
            var character = new Character
            {
                MaxHitPoints = 30,
                CurrentHitPoints = 10,
                Level = 6,
                HitDiceUsed = 4
            };

            // Act
            character.LongRest();

            // Assert
            character.CurrentHitPoints.Should().Be(30);
        }

        [Fact]
        public void Character_LongRest_ShouldRestoreHalfHitDice()
        {
            // Arrange
            var character = new Character
            {
                MaxHitPoints = 30,
                Level = 6,
                HitDiceUsed = 6
            };

            // Act
            character.LongRest();

            // Assert
            character.HitDiceUsed.Should().Be(3); // Recupera 3
            character.AvailableHitDice.Should().Be(3);
        }

        [Fact]
        public void Character_TotalArmorClass_ShouldCalculateCorrectly()
        {
            // Arrange
            var character = new Character
            {
                Abilities = new AbilityScores { Dexterity = 14 }, // +2
                AC = new ArmorClass
                {
                    Base = 10,
                    ArmorBonus = 5, // Chain mail
                    ShieldBonus = 2,
                    MagicBonus = 1
                }
            };

            // Act
            var totalAC = character.TotalArmorClass;

            // Assert
            totalAC.Should().Be(20); // 10 + 5 + 2 + 2 + 1
        }
    }
}
