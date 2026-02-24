using DnDSheetManager.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.Domain
{
    public class DamageResistancesTests
    {
        [Fact]
        public void CalculateDamageReceived_WithImmunity_ShouldReturnZero()
        {
            // Arrange
            var resistances = new DamageResistances();
            resistances.AddImmunity("Fogo");

            // Act
            var damage = resistances.CalculateDamageReceived(20, "Fogo");

            // Assert
            damage.Should().Be(0);
        }

        [Fact]
        public void CalculateDamageReceived_WithResistance_ShouldReturnHalf()
        {
            // Arrange
            var resistances = new DamageResistances();
            resistances.AddResistance("Frio");

            // Act
            var damage = resistances.CalculateDamageReceived(20, "Frio");

            // Assert
            damage.Should().Be(10);
        }

        [Fact]
        public void CalculateDamageReceived_WithVulnerability_ShouldReturnDouble()
        {
            // Arrange
            var resistances = new DamageResistances();
            resistances.AddVulnerability("Radiante");

            // Act
            var damage = resistances.CalculateDamageReceived(20, "Radiante");

            // Assert
            damage.Should().Be(40);
        }

        [Fact]
        public void CalculateDamageReceived_WithNormal_ShouldReturnSameValue()
        {
            // Arrange
            var resistances = new DamageResistances();

            // Act
            var damage = resistances.CalculateDamageReceived(20, "Cortante");

            // Assert
            damage.Should().Be(20);
        }

        [Fact]
        public void AddResistance_ShouldNotAddDuplicate()
        {
            // Arrange
            var resistances = new DamageResistances();

            // Act
            resistances.AddResistance("Fogo");
            resistances.AddResistance("Fogo");

            // Assert
            resistances.Resistances.Should().HaveCount(1);
        }
    }
}
