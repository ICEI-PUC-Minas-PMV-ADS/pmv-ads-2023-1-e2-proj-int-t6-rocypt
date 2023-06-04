using System.ComponentModel.DataAnnotations;

namespace Rocypt.Models
{
    public class RedefinirSenhaModel
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
