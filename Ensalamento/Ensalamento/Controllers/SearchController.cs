using Ensalamento.Data;
using Ensalamento.DTOs;
using Ensalamento.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ensalamento.Controllers
{
    public class SearchController : Controller
    {
        private readonly ESContext _context;
        private readonly ISearchService _searchService;

        public SearchController(ESContext context, ISearchService searchService)
        {
            _context = context;
            _searchService = searchService;
        }

        [HttpPost]
        public ActionResult SearchTeacher(IFormCollection collection)
        {
            string name = collection["teacherName"];
            ViewBag.Name = "Pedro Henrique";

            var result = _searchService.Find(name);
            return View(result);
        }

        public IActionResult Search()
        {
            ViewBag.Name = "Pedro Henrique";
            return View("SearchTeacher");
        }
    }
}
