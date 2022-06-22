using System.ComponentModel.DataAnnotations;

namespace Interxarifado.Models
{
    public class FuncionarioViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string senha { get; set; }
    }
}