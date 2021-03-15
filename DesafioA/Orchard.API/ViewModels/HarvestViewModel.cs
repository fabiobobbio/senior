using System;
using System.ComponentModel.DataAnnotations;

namespace Orchard.API.ViewModels
{
    public class HarvestViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Information { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal GrossWeight { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TreeId { get; set; }
    }
}