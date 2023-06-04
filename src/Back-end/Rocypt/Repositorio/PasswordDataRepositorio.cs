using Rocypt.Data;
using Rocypt.Models;

namespace Rocypt.Repositorio
{
    public class PasswordDataRepositorio : IPasswordDataRepositorio
    {
        private readonly DatabankContext _databankContext;

        public PasswordDataRepositorio(DatabankContext databankContext)
        {
            _databankContext = databankContext;
        }

        public List<PasswordModel> BuscarTodos(Guid gruposId)
        {
            return _databankContext.Password.Where(x => x.GrupoId == gruposId).ToList();
        }

        public PasswordModel BuscarPorId(Guid id)
        {
            return _databankContext.Password.FirstOrDefault(x => x.Id == id);
        }

        public PasswordModel Adicionar(PasswordModel password)
        {
            _databankContext.Password.Add(password);
            _databankContext.SaveChanges();
            return password;
        }

    }
}
