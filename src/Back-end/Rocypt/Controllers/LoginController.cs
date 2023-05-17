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
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _email = email;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Painel");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
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
                                new Claim(ClaimTypes.NameIdentifier, usuario.Name),
                                new Claim(ClaimTypes.Role, usuario.Role.ToString()),
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

        [HttpPost]
        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(redefinirSenhaModel.Email);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"<div><h3>Olá {usuario.Name},</h3>\nSua nova senha é: {novaSenha}</div>";
                        bool emailEnviado = _email.Enviar(usuario.Email, "🔑Rocypt - Nova Senha🔑", mensagem);
                        if (emailEnviado)
                        {
                            _usuarioRepositorio.AtualizarSenha(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente.";
                        }
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MesagemErro"] = $"Ops, não conseguimos redefinir sua senha! Verifique os dados informados.";
                }
                return View();
            }
            catch (Exception error)
            {
                TempData["MesagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente.";
                return RedirectToAction("Index");
            }
        }
    }
}
