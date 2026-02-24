using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class CreateCharacterDto
    {
        [Required(ErrorMessage = "O nome do personagem é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A espécie é obrigatória")]
        [StringLength(50, ErrorMessage = "A espécie deve ter no máximo 50 caracteres")]
        public string Species { get; set; } = string.Empty;

        [Required(ErrorMessage = "A classe é obrigatória")]
        [StringLength(50, ErrorMessage = "A classe deve ter no máximo 50 caracteres")]
        public string ClassName { get; set; } = string.Empty;

        [Range(1, 20, ErrorMessage = "O nível deve estar entre 1 e 20")]
        public int Level { get; set; } = 1;

        [Range(1, 1000, ErrorMessage = "Os pontos de vida máximos devem estar entre 1 e 1000")]
        public int MaxHitPoints { get; set; }

        [Range(0, 1000, ErrorMessage = "Os pontos de vida atuais devem estar entre 0 e 1000")]
        public int CurrentHitPoints { get; set; }

        public CreateAbilityScoresDto Abilities { get; set; } = new CreateAbilityScoresDto();
    }

    public class CreateAbilityScoresDto
    {
        [Range(1, 30, ErrorMessage = "Força deve estar entre 1 e 30")]
        public int Strength { get; set; } = 10;

        [Range(1, 30, ErrorMessage = "Destreza deve estar entre 1 e 30")]
        public int Dexterity { get; set; } = 10;

        [Range(1, 30, ErrorMessage = "Constituição deve estar entre 1 e 30")]
        public int Constitution { get; set; } = 10;

        [Range(1, 30, ErrorMessage = "Inteligência deve estar entre 1 e 30")]
        public int Intelligence { get; set; } = 10;

        [Range(1, 30, ErrorMessage = "Sabedoria deve estar entre 1 e 30")]
        public int Wisdom { get; set; } = 10;

        [Range(1, 30, ErrorMessage = "Carisma deve estar entre 1 e 30")]
        public int Charisma { get; set; } = 10;
    }
}
