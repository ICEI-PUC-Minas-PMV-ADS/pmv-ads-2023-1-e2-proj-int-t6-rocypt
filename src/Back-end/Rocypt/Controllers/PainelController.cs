using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Rocypt.Data;
using Rocypt.Models;
using Rocypt.Repositorio;

namespace Rocypt.Controllers
{
    public class PainelController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly DatabankContext _databankContext;

        public PainelController(IUsuarioRepositorio UsuarioRepositorio, DatabankContext databankContext)
        {
            _usuarioRepositorio = UsuarioRepositorio;
            _databankContext = databankContext;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarRegistros();
            return View(usuarios);
        }
        public IActionResult Deslogar()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
