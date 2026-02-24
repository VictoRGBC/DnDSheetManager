using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class CharacterActionDto
    {
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, 1000, ErrorMessage = "A quantidade deve estar entre 1 e 1000")]
        public int Amount { get; set; }
    }
}
