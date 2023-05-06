using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rocypt.Helpers;
using Rocypt.Models;
using Rocypt.Repositorio;

namespace Rocypt.Controllers
{
    public class RedefinirSenhaController : Controller
    {
        private readonly IEmail _email;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public RedefinirSenhaController(IEmail email, IUsuarioRepositorio usuarioRepositorio)
        {
            _email = email;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarToken(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(redefinirSenhaModel.Email);
                    if (usuario != null)
                    {
                        string novoToken = usuario.GerarToken();
                        string mensagem = $"<div><h3>Olá {usuario.Name},</h3>\nSeu token é: {novoToken}</div>";
                        bool emailEnviado = _email.Enviar(usuario.Email, "🔑Token redefinição de senha🔑", mensagem);
                        if (emailEnviado)
                        {
                            _usuarioRepositorio.ConfirmarToken(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail um token.";
                            return View("Verificacao");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente.";
                        }
                    }
                    TempData["MesagemErro"] = $"Ops, não conseguimos redefinir sua senha! Verifique os dados informados.";
                }
                TempData["MesagemErro"] = "Ops, não conseguimos recuperar sua senha.";
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MesagemErro"] = $"Ops, não conseguimos recuperar sua senha.";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Verificar(RedefinirSenhaModel redefinir)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorToken(redefinir.Token);
                    if (usuario != null)
                    {
                        if (usuario.TokenValido(usuario.Token))
                        {
                            TempData["MinhaChave"] = usuario.Token;
                            return View("Redefinir");
                        }
                    }
                    TempData["MesagemErro"] = $"O token não é valido.";
                    return View("Verificacao");
                }
                return View("Verificacao");
            }
            catch (Exception error)
            {
                TempData["MesagemErro"] = $"Ops, não conseguimos recuperar sua senha.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult AlterarSenha(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        string key = TempData["MinhaChave"] as string;
                        usuario = _usuarioRepositorio.BuscarPorToken(key);
                        if (usuario != null)
                        {
                            TempData["MesagemErro"] = $"Não foi possivel redefinir a senha";
                        }
                       
                        _usuarioRepositorio.AtualizarSenha(usuario);
                        return RedirectToAction("Sucesso");
                }
                return View("Redefinir");
            }
            catch (Exception error)
            {
                TempData["MesagemErro"] = $"Ops, não conseguimos alterar sua senha.";
                return RedirectToAction("Index");
            }
        }


    }
}
