using ControleLeitura2.Context;
using ControleLeitura2.Models;
using ControleLeitura2.Repositories.Interfaces;

namespace ControleLeitura2.Repositories
{
    public class PrioridadeRepository : IPrioridadeRepository
    {
        private readonly ControleLeituraContext _context;

        public PrioridadeRepository(ControleLeituraContext context)
        {
            _context = context;
        }

        public IEnumerable<Prioridade> Prioridades => _context.Prioridades;
    }
}
