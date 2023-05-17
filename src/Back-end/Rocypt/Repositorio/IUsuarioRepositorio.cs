using Rocypt.Models;

namespace Rocypt.Repositorio
{

	public interface IUsuarioRepositorio
	{
        UsuarioModel BuscarPorLogin(string email);
		UsuarioModel BuscarPorId(int id);
		UsuarioModel Adicionar(UsuarioModel usuario);
		UsuarioModel AtualizarSenha(UsuarioModel usuario);
        List<UsuarioModel> BuscarRegistros();
		public bool Apagar(int id);

    }
}
