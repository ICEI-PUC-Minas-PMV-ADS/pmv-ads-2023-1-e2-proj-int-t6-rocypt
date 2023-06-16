using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Rocypt.Helpers;
using Rocypt.Models;
using Rocypt.Repositorio;
using System.Security.Claims;

namespace Rocypt.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Painel");
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Email);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Password))
                        {
                            var claim = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, usuario.Name),
                                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                                new Claim(ClaimTypes.Role, usuario.Role.ToString()),
                                new Claim(ClaimTypes.Email, usuario.Email.ToString())
                            };
                            var userIndentify = new ClaimsIdentity(claim, "Login");
                            ClaimsPrincipal principal = new ClaimsPrincipal(userIndentify);
                            var props = new AuthenticationProperties
                            {
                                AllowRefresh = true,
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
                                IsPersistent = true
                            };
                            HttpContext.SignInAsync(principal, props);
                            return RedirectToAction("Index", "Painel");
                        }
                        TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MesagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente.";
                return RedirectToAction("Index");
            }
        }
    }
}
