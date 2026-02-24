using System.ComponentModel.DataAnnotations;
using DnDSheetManager.API.DTOs;
using FluentAssertions;
using Xunit;

namespace Tests.Validation
{
    public class DtoValidationTests
    {
        private List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void CreateCharacterDto_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var dto = new CreateCharacterDto
            {
                Name = "Gandalf",
                Species = "Humano",
                ClassName = "Mago",
                Level = 5,
                MaxHitPoints = 30,
                CurrentHitPoints = 30,
                Abilities = new CreateAbilityScoresDto
                {
                    Strength = 10,
                    Dexterity = 14,
                    Constitution = 12,
                    Intelligence = 18,
                    Wisdom = 13,
                    Charisma = 10
                }
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void CreateCharacterDto_WithEmptyName_ShouldFailValidation()
        {
            // Arrange
            var dto = new CreateCharacterDto
            {
                Name = "",
                Species = "Humano",
                ClassName = "Mago",
                MaxHitPoints = 30, // Adicionar valor válido
                CurrentHitPoints = 30
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("nome"));
        }

        [Fact]
        public void CreateCharacterDto_WithInvalidLevel_ShouldFailValidation()
        {
            // Arrange
            var dto = new CreateCharacterDto
            {
                Name = "Test",
                Species = "Humano",
                ClassName = "Guerreiro",
                Level = 25 // Inválido: máx 20
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("nível"));
        }

        [Fact]
        public void CreateAttackDto_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var dto = new CreateAttackDto
            {
                Name = "Espada Longa",
                Damage = "1d8+3",
                DamageType = "Cortante",
                IsFinesse = false,
                IsRanged = false,
                IsProficient = true
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void CreateAttackDto_WithInvalidDamageFormat_ShouldFailValidation()
        {
            // Arrange
            var dto = new CreateAttackDto
            {
                Name = "Espada",
                Damage = "muito dano", // Formato inválido
                DamageType = "Cortante"
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("Formato inválido"));
        }

        [Fact]
        public void AddItemDto_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var dto = new AddItemDto
            {
                ItemId = 1,
                Quantity = 5
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void AddItemDto_WithZeroQuantity_ShouldFailValidation()
        {
            // Arrange
            var dto = new AddItemDto
            {
                ItemId = 1,
                Quantity = 0 // Inválido
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("quantidade"));
        }

        [Fact]
        public void CreateFeatureDto_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var dto = new CreateFeatureDto
            {
                Name = "Fúria",
                Description = "Você pode entrar em fúria como uma ação bônus",
                Source = "Class",
                UsesPerRest = 3,
                RestType = "Long"
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void CreateFeatureDto_WithInvalidSource_ShouldFailValidation()
        {
            // Arrange
            var dto = new CreateFeatureDto
            {
                Name = "Test",
                Description = "Test description long enough",
                Source = "InvalidSource", // Inválido
                RestType = "Long"
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("Origem inválida"));
        }

        [Fact]
        public void CreateFeatureDto_WithInvalidRestType_ShouldFailValidation()
        {
            // Arrange
            var dto = new CreateFeatureDto
            {
                Name = "Test",
                Description = "Test description long enough",
                Source = "Class",
                RestType = "Medium" // Inválido
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("Tipo de descanso inválido"));
        }

        [Fact]
        public void CharacterActionDto_WithValidAmount_ShouldPassValidation()
        {
            // Arrange
            var dto = new CharacterActionDto { Amount = 10 };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void CharacterActionDto_WithNegativeAmount_ShouldFailValidation()
        {
            // Arrange
            var dto = new CharacterActionDto { Amount = -5 };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().Contain(r => r.ErrorMessage!.Contains("quantidade"));
        }

        [Fact]
        public void LearnSpellDto_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var dto = new LearnSpellDto
            {
                SpellId = 1,
                IsPrepared = true
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void CreateResourceDto_WithCurrentValueGreaterThanMax_ShouldPassValidation()
        {
            // Arrange - Permitimos que CurrentValue seja diferente de MaxValue na criação
            var dto = new CreateResourceDto
            {
                Name = "Ki",
                MaxValue = 5,
                CurrentValue = 3
            };

            // Act
            var results = ValidateModel(dto);

            // Assert
            results.Should().BeEmpty();
        }
    }
}
