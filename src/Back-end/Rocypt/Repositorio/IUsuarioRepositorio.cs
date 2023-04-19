using Rocypt.Models;

namespace Rocypt.Repositorio
{

	public interface IUsuarioRepositorio
	{
        UsuarioModel BuscarPorLogin(string email);
		UsuarioModel Adicionar(UsuarioModel usuario);
		UsuarioModel AtualizarSenha(UsuarioModel usuario);

    }
}
