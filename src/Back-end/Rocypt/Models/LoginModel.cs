using System.ComponentModel.DataAnnotations;

namespace Rocypt.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a Senha.")]
        public string Password { get; set; }

    }
}
