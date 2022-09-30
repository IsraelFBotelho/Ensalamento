using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Ensalamento.Models;
using Ensalamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ensalamento.Data;

namespace Ensalamento.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController : Controller
    {

        private ESContext _context;

        public LoginController(ESContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Auth model)
        {
            // Recupera o usuário

            var auth = _context.Auth.FirstOrDefault(c => c.Login == model.Login);

            // Verifica se o usuário existe
            // if (user == null || HashServices.GetHash(model.Password) != user.Password )
            if (auth == null || model.Password != auth.Password )
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var user = _context.User.FirstOrDefault(c => c.Id == auth.UserId);

            var role = _context.Role.FirstOrDefault(c => c.Id == user.RoleId);

            // Gera o Token
            var token = TokenServices.GenerateToken(user, role);

            // Retorna os dados
            return Ok(new {token = token});
        }
    }
}
