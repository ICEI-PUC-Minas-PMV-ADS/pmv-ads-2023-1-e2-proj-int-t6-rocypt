using Microsoft.AspNetCore.Mvc;
using Rocypt.Models;
using Rocypt.Repositorio;

namespace Rocypt.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try {
                if (ModelState.IsValid) {
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(usuario);
        }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não consegui concluir a tarefa. {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }   
}
