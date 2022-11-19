using Ensalamento.Data;

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


    }
}
