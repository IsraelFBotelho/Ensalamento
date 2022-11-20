using Ensalamento.Data;
using Ensalamento.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ensalamento.Services
{
    public interface ISearchService
    {
    }

    public class SearchService : ISearchService
    {
        private readonly ESContext _context;

        public SearchService(ESContext context)
        {
            _context = context;
        }

        private async Task<List<SearchResult>> FindAsync(string name)
        {
            
        }
    }
}
