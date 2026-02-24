using DnDSheetManager.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.Domain
{
    public class SpellSlotsTests
    {
        [Fact]
        public void SpellSlots_UseSlot_WithAvailableSlots_ShouldReturnTrue()
        {
            // Arrange
            var spellSlots = new SpellSlots
            {
                Level1Total = 4,
                Level1Used = 0
            };

            // Act
            var result = spellSlots.UseSlot(1);

            // Assert
            result.Should().BeTrue();
            spellSlots.Level1Used.Should().Be(1);
        }

        [Fact]
        public void SpellSlots_UseSlot_WithNoAvailableSlots_ShouldReturnFalse()
        {
            // Arrange
            var spellSlots = new SpellSlots
            {
                Level1Total = 2,
                Level1Used = 2
            };

            // Act
            var result = spellSlots.UseSlot(1);

            // Assert
            result.Should().BeFalse();
            spellSlots.Level1Used.Should().Be(2);
        }

        [Fact]
        public void SpellSlots_GetAvailable_ShouldReturnCorrectValue()
        {
            // Arrange
            var spellSlots = new SpellSlots
            {
                Level3Total = 3,
                Level3Used = 1
            };

            // Act
            var available = spellSlots.GetAvailable(3);

            // Assert
            available.Should().Be(2);
        }

        [Fact]
        public void SpellSlots_RestoreSlot_ShouldDecreaseUsedCount()
        {
            // Arrange
            var spellSlots = new SpellSlots
            {
                Level2Total = 3,
                Level2Used = 2
            };

            // Act
            spellSlots.RestoreSlot(2);

            // Assert
            spellSlots.Level2Used.Should().Be(1);
        }

        [Fact]
        public void SpellSlots_LongRest_ShouldRestoreAllSlots()
        {
            // Arrange
            var spellSlots = new SpellSlots
            {
                Level1Total = 4,
                Level1Used = 3,
                Level2Total = 3,
                Level2Used = 2,
                Level3Total = 2,
                Level3Used = 2
            };

            // Act
            spellSlots.LongRest();

            // Assert
            spellSlots.Level1Used.Should().Be(0);
            spellSlots.Level2Used.Should().Be(0);
            spellSlots.Level3Used.Should().Be(0);
        }
    }
}
