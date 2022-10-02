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
    }
}
