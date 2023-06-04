using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rocypt.Helpers;


namespace Rocypt.Models
{
	public class UsuarioModel
	{

		public Guid Id { get; set; } = Guid.NewGuid();
		[Required(ErrorMessage = "Digite o nome do usuário.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Digite o seu email.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Digite a sua senha.")]
		public string Password { get; set; }
		public string Role { get; set; } = "User";
		public string? Token { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		public virtual List<GrupoModel>? Grupo { get; set; }

		public void SetSenhaHash()
		{
			Password = Password.GerarHash();
		}

		public bool SenhaValida(string password)
		{
			return Password == password.GerarHash();
		}

		public bool TokenValido(string token)
		{
			return Token == token;
		}
		public string GerarToken()
		{
			string novoToken = Guid.NewGuid().ToString().Substring(0, 6);
			Token = novoToken;
			return novoToken;
		}

		public string GerarNovaSenha()
		{
			string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);

			Password = novaSenha.GerarHash();
			return novaSenha;
		}



	}
}
