using System;
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

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(Auth auth)
        {
            var user = _context.Auth.FirstOrDefault(c => c.Login == auth.Login);

            if (user == null || auth.Password != user.Password)
            {
                return RedirectToAction("Index", new { erroLogin = true });
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
        public IActionResult Index(bool errologin)
        {

            if (errologin)
            {
                ViewBag.Erro = "Login e/ou senha incorretos";
            }
            
            return View();
        }

        public IActionResult Profile()
        {
            ViewBag.Permissoes = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
            return View();
        }
    }
}
