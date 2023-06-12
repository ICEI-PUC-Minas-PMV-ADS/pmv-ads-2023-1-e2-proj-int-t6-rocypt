using Rocypt.Models;

namespace Rocypt.Repositorio
{
    public interface IPasswordDataRepositorio
    {
        public PasswordModel Adicionar(PasswordModel pass);
        public PasswordModel BuscarPorId(Guid id);
        public List<PasswordModel> BuscarTodos(Guid grupoId);
        public PasswordModel Alterar(PasswordModel pass);
        public bool Apagar(Guid id);

    }
}
