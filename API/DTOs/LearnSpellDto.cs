using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class LearnSpellDto
    {
        [Required(ErrorMessage = "O ID da magia é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID da magia deve ser maior que 0")]
        public int SpellId { get; set; }

        public bool IsPrepared { get; set; }
    }
}
