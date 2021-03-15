using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Orchard.API.ViewModels
{
    public class TreeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Age { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int SpecieId { get; set; }
    }
}