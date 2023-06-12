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
                        string mensagem = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <style>\r\n    body {{\r\n      background-color: #f2e6ff;\r\n      font-family: Arial, sans-serif;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n\r\n    .container {{\r\n      max-width: 600px;\r\n      margin: 0 auto;\r\n      padding: 20px;\r\n    }}\r\n\r\n    h1 {{\r\n      color: #800080;\r\n    }}\r\n\r\n    p {{\r\n      color: #333333;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <h1>Recuperação de senha</h1>\r\n\r\n    <p>Prezado(a) {usuario.Name},</p>\r\n\r\n    <p>Este é seu token de validação. Por favor, utilize-o para gerar uma nova senha:</p>\r\n\r\n    <div class=\"token\">\r\n      <p><strong>{novoToken}</strong></p>\r\n    </div>\r\n\r\n    <p>Caso não tenha solicitado a recuperação de senha ou se tiver qualquer dúvida, por favor, entre em contato conosco imediatamente. Estamos aqui para ajudar e garantir a segurança de sua conta.</p>\r\n\r\n    <p>Atenciosamente,</p>\r\n\r\n    <p>Rocypt<br>\r\n    rocypttest@outlook.com<br>\r\n    (31)9999-9999</p>\r\n  </div>\r\n</body>\r\n</html>\r\n";
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
                            string novaSenha = usuario.GerarNovaSenha();
                            string mensagem = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <style>\r\n    body {{\r\n      background-color: #f2e6ff;\r\n      font-family: Arial, sans-serif;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n\r\n    .container {{\r\n      max-width: 600px;\r\n      margin: 0 auto;\r\n      padding: 20px;\r\n    }}\r\n\r\n    h1 {{\r\n      color: #800080;\r\n    }}\r\n\r\n    p {{\r\n      color: #333333;\r\n    }}\r\n\r\n    .password {{\r\n      background-color: #e6ccff;\r\n      border-radius: 4px;\r\n      padding: 10px;\r\n      margin-bottom: 20px;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n   \t<h1>Ro<span style=\"color: rgb(162, 0, 255)\">cyp</span>t</h1>\r\n\r\n    <p>Prezado(a) {usuario.Name},</p>\r\n\r\n    <p>Espero que esta mensagem o(a) encontre bem e com boas energias! Gostaríamos de informar que sua senha foi redefinida com sucesso. Para garantir a segurança dos seus dados e facilitar o acesso à sua conta, criamos uma senha nova especialmente para você.</p>\r\n\r\n    <div class=\"password\">\r\n      <p>Senha: <strong>{novaSenha}</strong></p>\r\n    </div>\r\n\r\n    <p>Lembramos que é importante manter sua senha segura e não compartilhá-la com ninguém. Recomendamos que você a memorize ou a anote em um local seguro.</p>\r\n\r\n    <p>Caso não tenha solicitado a alteração da senha ou se tiver qualquer dúvida, por favor, entre em contato conosco imediatamente. Estamos aqui para ajudar e garantir que sua experiência conosco seja sempre agradável e segura.</p>\r\n\r\n    <p>Agradecemos pela confiança em nossos serviços e esperamos continuar atendendo às suas expectativas. Se tiver alguma sugestão ou feedback, não hesite em compartilhá-los conosco. Sua opinião é muito importante para nós.</p>\r\n\r\n    <p>Tenha um excelente dia!</p>\r\n\r\n    <p>Atenciosamente,</p>\r\n\r\n    <p>Rocypt<br>\r\n    rocypttest@outlook.com<br>\r\n    (31)9999-9999</p>\r\n  </div>\r\n</body>\r\n</html>\r\n";
                            bool emailEnviado = _email.Enviar(usuario.Email, "Senha Alterada com sucesso! ✅", mensagem);
                            if (emailEnviado)
                            {
                                _usuarioRepositorio.AtualizarSenha(usuario);
                                TempData["MensagemSucesso"] = $"Enviamos uma nova senha para seu email.";
                                return View("Sucesso");
                            }
                            else
                            {
                                TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente.";
                            }
                            return RedirectToAction("sucesso");
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

    }
}
