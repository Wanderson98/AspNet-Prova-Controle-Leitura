using ControleLeitura2.Context;
using ControleLeitura2.Models;
using ControleLeitura2.Repositories.Interfaces;

namespace ControleLeitura2.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ControleLeituraContext _context;

        public CategoriaRepository(ControleLeituraContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
