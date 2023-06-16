using System.ComponentModel.DataAnnotations;

namespace Rocypt.Models
{
    public class PasswordModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Password é nescessario ter um nome.")]
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid GrupoId { get; set; }
        public GrupoModel? Grupo { get; set; }

    }
}
