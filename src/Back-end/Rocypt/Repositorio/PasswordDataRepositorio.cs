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

        public PasswordModel Alterar(PasswordModel pass)
        {
            PasswordModel passDb = BuscarPorId(pass.Id);

            if (passDb == null) throw new Exception("Houve um erro na atualização!");

            passDb.Name = pass.Name;
            passDb.UserName = pass.UserName;
            passDb.Senha = pass.Senha;
            passDb.Email = pass.Email;

            _databankContext.Password.Update(passDb);
            _databankContext.SaveChanges();
            return passDb;
        }

        public bool Apagar(Guid id)
        {
            PasswordModel passDb = BuscarPorId(id);
            if (passDb == null) throw new Exception("Houve um erro na deleção!");

            _databankContext.Password.Remove(passDb);
            _databankContext.SaveChanges();

            return true;
        }

    }
}
