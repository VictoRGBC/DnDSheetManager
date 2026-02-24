using DnDSheetManager.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.Domain
{
    public class AbilityScoresTests
    {
        [Theory]
        [InlineData(1, -5)]
        [InlineData(8, -1)]
        [InlineData(10, 0)]
        [InlineData(12, 1)]
        [InlineData(14, 2)]
        [InlineData(16, 3)]
        [InlineData(18, 4)]
        [InlineData(20, 5)]
        [InlineData(30, 10)]
        public void AbilityModifier_ShouldBeCalculatedCorrectly(int score, int expectedModifier)
        {
            // Arrange
            var abilities = new AbilityScores { Strength = score };

            // Act
            var modifier = abilities.StrengthModifier;

            // Assert
            modifier.Should().Be(expectedModifier);
        }

        [Fact]
        public void AllAbilityModifiers_ShouldBeCalculatedCorrectly()
        {
            // Arrange
            var abilities = new AbilityScores
            {
                Strength = 16,
                Dexterity = 14,
                Constitution = 12,
                Intelligence = 18,
                Wisdom = 10,
                Charisma = 8
            };

            // Assert
            abilities.StrengthModifier.Should().Be(3);
            abilities.DexterityModifier.Should().Be(2);
            abilities.ConstitutionModifier.Should().Be(1);
            abilities.IntelligenceModifier.Should().Be(4);
            abilities.WisdomModifier.Should().Be(0);
            abilities.CharismaModifier.Should().Be(-1);
        }
    }
}
