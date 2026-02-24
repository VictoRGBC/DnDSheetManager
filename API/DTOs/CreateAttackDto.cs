using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class CreateAttackDto
    {
        [Required(ErrorMessage = "O nome do ataque é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O dano é obrigatório")]
        [StringLength(50, ErrorMessage = "O dano deve ter no máximo 50 caracteres")]
        [RegularExpression(@"^\d+d\d+(\+\d+)?$", ErrorMessage = "Formato inválido. Use: NdN ou NdN+N (ex: 1d8, 2d6+3)")]
        public string Damage { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de dano é obrigatório")]
        [StringLength(50, ErrorMessage = "O tipo de dano deve ter no máximo 50 caracteres")]
        public string DamageType { get; set; } = string.Empty;

        public bool IsRanged { get; set; }
        public bool IsFinesse { get; set; }
        public bool IsProficient { get; set; }
    }
}
