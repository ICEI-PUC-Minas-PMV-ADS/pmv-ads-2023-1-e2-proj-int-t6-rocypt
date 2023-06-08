using Microsoft.EntityFrameworkCore;
using Rocypt.Models;

namespace Rocypt.Repositorio
{
    public interface IGrupoRepositorio
    {
        public GrupoModel Adicionar(GrupoModel grupo);
        public GrupoModel Atualizar(GrupoModel grupo);
        public bool Apagar(Guid id);
        public GrupoModel BuscarPorId(Guid id);
        public List<GrupoModel> BuscarTodos(Guid usuarioId);
    }
}
