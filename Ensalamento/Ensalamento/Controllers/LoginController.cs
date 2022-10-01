using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensalamento.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthenticateUser()
        {
            return View();
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
    }

}
