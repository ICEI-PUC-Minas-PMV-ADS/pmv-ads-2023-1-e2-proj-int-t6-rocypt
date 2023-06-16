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
		public IActionResult Criar(UsuarioModel usuario, string senhaConfirmacao)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if(_usuarioRepositorio.BuscarPorLogin(usuario.Email) != null)
					{
                        TempData["MensagemErro"] = "Este email já esta cadastrado.";
						return RedirectToAction("Index", usuario);
					}
					
					if (usuario.Password != senhaConfirmacao)
					{
						TempData["MensagemErro"] = "As senhas não coincidem.";
						return View("Index", usuario);
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
