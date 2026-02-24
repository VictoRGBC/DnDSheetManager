using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class CreateResourceDto
    {
        [Required(ErrorMessage = "O nome do recurso é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor máximo é obrigatório")]
        [Range(1, 100, ErrorMessage = "O valor máximo deve estar entre 1 e 100")]
        public int MaxValue { get; set; }

        [Required(ErrorMessage = "O valor atual é obrigatório")]
        [Range(0, 100, ErrorMessage = "O valor atual deve estar entre 0 e 100")]
        public int CurrentValue { get; set; }
    }
}
