using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Ensalamento.Models;
using Ensalamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ensalamento.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Ensalamento.Controllers
{
    public class LoginController : Controller
    {
        
        private ESContext _context;

        private readonly ILogger<HomeController> _logger;


        public LoginController(ILogger<HomeController> logger, ESContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult UserPanelCoordinator()
        {
            return View();
        }

        public IActionResult UserPanelTeacher()
        {
            return View();
        }

        public IActionResult UserPanelStudent()
        {
            return View();
        }

        public IActionResult UserPanelSecretary()
        {
            return View();
        }
        
        public IActionResult SelectUser()
        {
            return View("AuthenticateUser");
        }
        
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(Auth auth)
        {
            var user = _context.Auth.FirstOrDefault(c => c.Login == auth.Login);

            if (user == null || auth.Password != user.Password)
            {
                return RedirectToAction("Erro", new { erroLogin = true });
            }

            var userdb = _context.User.FirstOrDefault(c => c.Id == user.UserId);
            var role = _context.Role.FirstOrDefault(c => c.Id == userdb.RoleId);
            
            await new LoginServices().Login(HttpContext, userdb, role);

            return RedirectToAction("Profile");
        }
        
        [Authorize]
        public IActionResult Profile()
        {
            TextInfo myTI = new CultureInfo("PT-br",false).TextInfo;
            
            ViewBag.Permissoes = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).SingleOrDefault();
            ViewBag.Nome = myTI.ToTitleCase(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value)
                .SingleOrDefault() ?? string.Empty);

            if (ViewBag.Permissoes.ToString() == "estudante")
            {
                return View("../Login/UserPanelStudent");
            }
            else if (ViewBag.Permissoes == "professor")
            {
                return View("../Login/UserPanelTeacher");
            }
            else if (ViewBag.Permissoes == "coordenador")
            {
                return View("../Login/UserPanelCoordinator");
            }
            else if (ViewBag.Permissoes == "secretaria")
            {
                return View("../Login/UserPanelTeacher");
            }


            ViewBag.Erro = "Sessão Inválida";
            return View("../Login/AuthenticateUser");
        }
        
        [AllowAnonymous]
        public IActionResult Erro(bool errologin)
        {
            if (errologin)
            {
                ViewBag.Erro = "Login e/ou senha incorretos";
            }
            
            return View("../Login/AuthenticateUser");
        }
        
        [Authorize]
        public async Task<IActionResult> Sair()
        {
            await new LoginServices().Logoff(HttpContext);
            return RedirectToAction("Index","Home");
        }
    }
}
