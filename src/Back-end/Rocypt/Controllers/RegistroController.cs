using Microsoft.AspNetCore.Mvc;
using Rocypt.Models;
using Rocypt.Repositorio;

namespace Rocypt.Controllers
{
	public class RegistroController : Controller
	{
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		public RegistroController(IUsuarioRepositorio usuarioRepositorio)
		{
			_usuarioRepositorio = usuarioRepositorio;
		}
		public IActionResult Index()
		{
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Painel");
            return View();
		}


		[HttpPost]
		public IActionResult Criar(UsuarioModel usuario)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if(_usuarioRepositorio.BuscarPorLogin(usuario.Email) != null)
					{
                        TempData["MensagemErro"] = "Este email já esta cadastrado.";
						RedirectToAction("Index", "Registro");
                    } else
					usuario = _usuarioRepositorio.Adicionar(usuario);
					TempData["MensagemSucesso"] = "Usuario Cadastrado com sucesso.";
					return RedirectToAction("Index", "Login");
				}
				return View();
			}
			catch (Exception erro)
			{
				TempData["MensagemErro"] = $"Ops, não consegui concluir a tarefa. {erro.Message}";
				return RedirectToAction("Index");
			}
		}
	}
}
