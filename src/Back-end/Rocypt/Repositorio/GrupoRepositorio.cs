using Microsoft.EntityFrameworkCore;
using Rocypt.Data;
using Rocypt.Models;

namespace Rocypt.Repositorio
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private readonly DatabankContext _databankContext;

        public GrupoRepositorio(DatabankContext databankContext) 
        {
            _databankContext = databankContext;
        }

        public List<GrupoModel> BuscarTodos(Guid usuarioId)
        {
            return _databankContext.Grupo.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public List<PasswordModel> BuscarTodosPass(Guid groupId)
        {
            return _databankContext.Password.Where(x => x.GrupoId == groupId).ToList();
        }

        public GrupoModel BuscarPorId(Guid id)
        {
            return _databankContext.Grupo.FirstOrDefault(x => x.Id == id);
        }

        public PasswordModel BuscarPorIdPass(Guid id)
        {
            return _databankContext.Password.FirstOrDefault(x => x.GrupoId == id);
        }

        public GrupoModel Adicionar(GrupoModel grupo)
        {
            _databankContext.Grupo.Add(grupo);
            _databankContext.SaveChanges();
            return grupo;
        }

        public GrupoModel Atualizar(GrupoModel grupo)
        {
            GrupoModel grupoDb = BuscarPorId(grupo.Id);

            if (grupoDb == null) throw new Exception("Houve um erro na atualização!");

            grupoDb.Name = grupo.Name;

            _databankContext.Grupo.Update(grupoDb);
            _databankContext.SaveChanges();
            return grupoDb;
        }

        public bool Apagar(Guid id)
        {
            GrupoModel grupoDb = BuscarPorId(id);
            if (grupoDb == null) throw new Exception("Houve um erro na deleção!");
            List<PasswordModel> pass = BuscarTodosPass(id);
            _databankContext.Grupo.Remove(grupoDb);
            _databankContext.SaveChanges();

            return true;
        }

    }
}
