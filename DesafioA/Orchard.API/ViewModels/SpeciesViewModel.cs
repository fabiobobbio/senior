using System.ComponentModel.DataAnnotations;

namespace Orchard.API.ViewModels
{
    public class SpeciesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Description { get; set; }
    }
}