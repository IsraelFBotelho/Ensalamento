using Ensalamento.Data;
using Ensalamento.Services;
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

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string name)
        {
            string _name = "a";

            Console.WriteLine("Running IndexAsync()\n\n");

            var result = await _searchService.FindAsync(_name);
            // ViewBag.Result = result;

            if (!result.Any())
            {
                Console.WriteLine("Nenhum resultado encontrado!");
                return NoContent();
            }

            foreach (var e in result)
            {
                Console.WriteLine("Código da Disciplina: " + e.SubjectId);
                Console.WriteLine("Disciplina: " + e.SubjectName);
                Console.WriteLine("Professor: " + e.TeacherName);
                Console.WriteLine("Dia e Horário: " + e.Date);
                Console.WriteLine("Sala: " + e.ClassId);
                Console.WriteLine("Categoria do Evento: " + e.EventName + "\n");
            }

            return Ok();
        }

        public IActionResult Search()
        {
            return View("SearchTeacher");
        }
    }
}
