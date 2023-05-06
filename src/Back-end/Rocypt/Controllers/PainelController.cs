using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocypt.Data;
using Rocypt.Models;
using Rocypt.Repositorio;
using System.Security.Claims;

namespace Rocypt.Controllers
{
    public class PainelController : Controller
    {
        private readonly IGrupoRepositorio _grupoRespositorio;
        private readonly DatabankContext _databankContext;


        public PainelController(IGrupoRepositorio grupoRepositorio, DatabankContext databankContext)
        {
            _grupoRespositorio = grupoRepositorio;
            _databankContext = databankContext;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<GrupoModel> grupos = _grupoRespositorio.BuscarTodos(Guid.Parse(userId));
            return View(grupos);
        }

        [HttpGet]
        public IActionResult CriarGrupo()
        {
            return View();
        }

        public IActionResult Deslogar()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult CriarGrupo(GrupoModel grupo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    UsuarioModel usuario = _databankContext.Usuarios.Find(Guid.Parse(userId));
                    grupo.UsuarioId = usuario.Id;
                    grupo = _grupoRespositorio.Adicionar(grupo);
                    return RedirectToAction("Index");
                }
                return View();
            }catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar um grupo, tente novamante, detalhe do erro: {erro.Message}";
                return View();
            }

        }

      
        public IActionResult Apagar(Guid id)
        {
            try
            {
                bool apagado = _grupoRespositorio.Apagar(id);

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
