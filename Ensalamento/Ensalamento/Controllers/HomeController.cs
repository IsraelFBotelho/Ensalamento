using Ensalamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ensalamento.Data;
using Ensalamento.Services;
using Microsoft.AspNetCore.Authorization;

namespace Ensalamento.Controllers
{
    public class HomeController : Controller
    {

        private ESContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ESContext context)
        {
            _logger = logger;
            _context = context;
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
        public async Task<IActionResult> Sair()
        {
            await new LoginServices().Logoff(HttpContext);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}
