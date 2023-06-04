using Newtonsoft.Json.Linq;
using Rocypt.Data;
using Rocypt.Models;

namespace Rocypt.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DatabankContext _databankContext;
        public UsuarioRepositorio(DatabankContext databankContext)
        {
            _databankContext = databankContext;
        }

        public UsuarioModel BuscarPorToken(string token)
        {
            return _databankContext.Usuarios.FirstOrDefault(x=> x.Token == token);
        }
        public UsuarioModel BuscarPorId(Guid id)
        {
            return _databankContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _databankContext.Usuarios.Add(usuario);
            usuario.SetSenhaHash();
            _databankContext.SaveChanges();
            return usuario;
        }

        public bool Apagar(Guid id)
        {
            UsuarioModel usuario = BuscarPorId(id);
            _databankContext.Usuarios.Remove(usuario);
            _databankContext.SaveChanges();

            return true;
        }

		public UsuarioModel ConfirmarToken(UsuarioModel usuario)
		{
			UsuarioModel usuarioDb = BuscarPorId(usuario.Id);
			if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuario");

            usuarioDb.Token = usuario.Token;
			_databankContext.Usuarios.Update(usuario);
			_databankContext.SaveChanges();
			return usuarioDb;
		}

		public UsuarioModel AtualizarSenha(RedefinirSenhaModel usuario)
        {
            UsuarioModel usuarioDb = BuscarPorToken(usuario.Token);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuario");

            usuarioDb.Password = usuario.Password;
            _databankContext.Usuarios.Update(usuarioDb);
            _databankContext.SaveChanges();
            return usuarioDb;
        }

        public UsuarioModel BuscarPorLogin(string email)
        {
            return _databankContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }


        public List<GrupoModel> BuscarTodosGrupos(Guid usuarioId)
        {
            return _databankContext.Grupo.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public List<UsuarioModel> BuscarRegistros()
        {
            return _databankContext.Usuarios.ToList();
        }
    }
}
