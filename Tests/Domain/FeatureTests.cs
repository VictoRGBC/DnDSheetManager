using DnDSheetManager.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Tests.Domain
{
    public class FeatureTests
    {
        [Fact]
        public void Feature_Use_ShouldDecreaseUsesRemaining()
        {
            // Arrange
            var feature = new Feature
            {
                Name = "Fúria",
                UsesPerRest = 3,
                UsesRemaining = 3
            };

            // Act
            feature.Use();

            // Assert
            feature.UsesRemaining.Should().Be(2);
        }

        [Fact]
        public void Feature_Use_WhenZeroUses_ShouldNotGoNegative()
        {
            // Arrange
            var feature = new Feature
            {
                Name = "Fúria",
                UsesPerRest = 3,
                UsesRemaining = 0
            };

            // Act
            feature.Use();

            // Assert
            feature.UsesRemaining.Should().Be(0);
        }

        [Fact]
        public void Feature_RestoreUses_ShouldRestoreToMax()
        {
            // Arrange
            var feature = new Feature
            {
                Name = "Fúria",
                UsesPerRest = 3,
                UsesRemaining = 1
            };

            // Act
            feature.RestoreUses();

            // Assert
            feature.UsesRemaining.Should().Be(3);
        }

        [Fact]
        public void Feature_WithoutUsesLimit_ShouldNotDecrease()
        {
            // Arrange
            var feature = new Feature
            {
                Name = "Ataque Furtivo",
                UsesPerRest = null,
                UsesRemaining = null
            };

            // Act
            feature.Use();

            // Assert
            feature.UsesRemaining.Should().BeNull();
        }
    }
}
