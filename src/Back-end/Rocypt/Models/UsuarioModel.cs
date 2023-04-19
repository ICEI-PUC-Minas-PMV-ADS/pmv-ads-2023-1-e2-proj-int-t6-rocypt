using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rocypt.Helpers;


namespace Rocypt.Models
{
	public class UsuarioModel
	{

		public int Id { get; set; }
		[Required(ErrorMessage = "Digite o nome do usuário.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Digite o seu email.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Digite a sua senha.")]
		public string Password { get; set; }
		public string Role { get; set; } = "User";
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		public void SetSenhaHash()
		{
			Password = Password.GerarHash();
		}

		public bool SenhaValida(string password)
		{
			return Password == password.GerarHash();
		}

		public string GerarNovaSenha()
		{
			string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);

			Password = novaSenha.GerarHash();
			return novaSenha;
		}

	}
}
