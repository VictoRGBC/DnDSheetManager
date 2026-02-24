using System.ComponentModel.DataAnnotations;

namespace DnDSheetManager.API.DTOs
{
    public class AddItemDto
    {
        [Required(ErrorMessage = "O ID do item é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do item deve ser maior que 0")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, 999, ErrorMessage = "A quantidade deve estar entre 1 e 999")]
        public int Quantity { get; set; }
    }
}
