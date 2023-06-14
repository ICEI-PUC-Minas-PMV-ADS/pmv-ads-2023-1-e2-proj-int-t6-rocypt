using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPasswordDataRepositorio _passwordDataRespositorio;
        private int a;


        public PainelController(IGrupoRepositorio grupoRepositorio, IPasswordDataRepositorio passwordDataRespositorio, DatabankContext databankContext)
        {
            _grupoRespositorio = grupoRepositorio;
            _passwordDataRespositorio = passwordDataRespositorio;
            _databankContext = databankContext;

        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = new PainelIndexModel();
            model.grupoModels = _grupoRespositorio.BuscarTodos(Guid.Parse(userId));
            return View(model);
        }


        public IActionResult Deslogar()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult CriarGrupo(GrupoModel grupo)
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
        }

        [HttpPost]
        public IActionResult Alterar(GrupoModel grupo)
        {

            if (ModelState.IsValid)
            {
                grupo = _grupoRespositorio.Atualizar(grupo);
                _databankContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }


        public IActionResult Apagar(Guid id)
        {
            bool apagado = _grupoRespositorio.Apagar(id);
            return RedirectToAction("Index");
        }



        public IActionResult ListarSenhasPorGruposId(string id)
        {
            if (Guid.TryParse(id, out Guid groupId))
            {
                List<PasswordModel> pass = _passwordDataRespositorio.BuscarTodos(groupId);
                return PartialView("_Senhas", pass);
            }
            else
            {
                // Trate o caso em que o ID não é um formato válido de Guid
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CriarPass(PasswordModel pass)
        {
            if (ModelState.IsValid)
            {
                pass = _passwordDataRespositorio.Adicionar(pass);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AlterarPass(PasswordModel pass)
        {

            if (ModelState.IsValid)
            {
                pass = _passwordDataRespositorio.Alterar(pass);
                _databankContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public IActionResult ApagarPass(Guid id)
        {
            bool apagado = _passwordDataRespositorio.Apagar(id);
            return RedirectToAction("Index");
        }

    }
}
