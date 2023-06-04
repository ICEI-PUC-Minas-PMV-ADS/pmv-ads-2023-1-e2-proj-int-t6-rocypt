using Microsoft.EntityFrameworkCore;
using Rocypt.Models;

namespace Rocypt.Repositorio
{
    public interface IGrupoRepositorio
    {
        public GrupoModel Adicionar(GrupoModel grupo);
        public GrupoModel Atualizar(GrupoModel grupo);
        public GrupoModel Apagar(GrupoModel grupo);
        public GrupoModel BuscarPorId(Guid id);
        public List<GrupoModel> BuscarTodos(Guid usuarioId);
    }
}
