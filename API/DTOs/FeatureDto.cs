using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public int? UsesPerRest { get; set; }
        public int? UsesRemaining { get; set; }
        public string? RestType { get; set; }
    }

    public class CreateFeatureDto
    {
        [Required(ErrorMessage = "O nome da característica é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 1000 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A origem é obrigatória")]
        [RegularExpression(@"^(Racial|Class|Feat|Background)$", ErrorMessage = "Origem inválida. Use: Racial, Class, Feat ou Background")]
        public string Source { get; set; } = string.Empty;

        [Range(1, 20, ErrorMessage = "Usos por descanso deve estar entre 1 e 20")]
        public int? UsesPerRest { get; set; }

        [RegularExpression(@"^(Short|Long)$", ErrorMessage = "Tipo de descanso inválido. Use: Short ou Long")]
        public string? RestType { get; set; }
    }
}
