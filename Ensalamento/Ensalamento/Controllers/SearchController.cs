using Ensalamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ensalamento.Controllers
{
    public class SearchController : Controller
    {
        private SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string name)
        {
            var result = await _searchService.FindAsync(name);
            return View();
        }
    }
}
