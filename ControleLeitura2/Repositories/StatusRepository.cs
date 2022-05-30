using ControleLeitura2.Context;
using ControleLeitura2.Models;
using ControleLeitura2.Repositories.Interfaces;

namespace ControleLeitura2.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ControleLeituraContext _context;

        public StatusRepository(ControleLeituraContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> Status => _context.Status;
    }
}
