using Rocypt.Models;

namespace Rocypt.Repositorio
{

	public interface IUsuarioRepositorio
	{
        UsuarioModel BuscarPorLogin(string email);
		public UsuarioModel BuscarPorToken(string token);
        UsuarioModel BuscarPorId(Guid id);
		UsuarioModel Adicionar(UsuarioModel usuario);
		UsuarioModel AtualizarSenha(RedefinirSenhaModel usuario);
		UsuarioModel ConfirmarToken(UsuarioModel usuario);
		public List<GrupoModel> BuscarTodosGrupos(Guid usuarioId);

        List<UsuarioModel> BuscarRegistros();
		public bool Apagar(Guid id);

    }
}
