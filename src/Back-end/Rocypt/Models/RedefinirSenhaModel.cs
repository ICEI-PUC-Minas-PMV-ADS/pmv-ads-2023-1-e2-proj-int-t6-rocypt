using System.ComponentModel.DataAnnotations;

namespace Rocypt.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login.")]
        public string Email { get; set; }
    }
}
