using System.ComponentModel.DataAnnotations;

namespace Rocypt.Models
{
    public class GrupoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Grupo é nescessario ter um nome.")]
        public string Name { get; set; }

        public Guid? UsuarioId { get; set; }
        
        public UsuarioModel? Usuario { get; set; }

    }
}
