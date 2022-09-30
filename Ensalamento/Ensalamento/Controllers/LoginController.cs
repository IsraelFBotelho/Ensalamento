using System.Linq;
using Ensalamento.Models;
using Ensalamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ensalamento.Data;

namespace Ensalamento.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Auth model)
        {
            // Recupera o usuário

            var db = new ESContext();

            var user = db.Auth.FirstOrDefault(c => c.Login == model.Login);

            // Verifica se o usuário existe
            if (user == null || HashServices.GetHash(model.Password) != user.Password )
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenServices.GenerateToken(user);

            // Retorna os dados
            return Ok(new {token = token});
        }
    }
}
