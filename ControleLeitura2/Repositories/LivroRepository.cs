using ControleLeitura2.Context;
using ControleLeitura2.Models;
using ControleLeitura2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleLeitura2.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ControleLeituraContext _context;

        public LivroRepository(ControleLeituraContext context)
        {
            _context = context;
        }

        public IEnumerable<Livro> Livros => _context.Livros.Include(c => c.Categoria).Include(c => c.Editora)
            .Include(c=> c.Autor).Include(c=> c.Status).Include(c=>c.Prioridade);

        public IEnumerable<Livro> LivrosFavoritos => _context.Livros.Where(c=> c.IsFavorito).
            Include(c => c.Categoria).Include(c => c.Editora).Include(c => c.Autor).Include(c => c.Status).Include(c => c.Prioridade)
            .OrderBy(c=> c.StatusId);

        public IEnumerable<Livro> LivrosLendoAgora => _context.Livros.Where(c=>c.StatusId == 2).
            Include(c => c.Categoria).Include(c => c.Editora).Include(c => c.Autor).Include(c => c.Status).Include(c => c.Prioridade).
            OrderBy(c=> c.PrioridadeId);

        public IEnumerable<Livro> LivrosParaLer => _context.Livros.Where(c => c.StatusId == 1).
            Include(c => c.Categoria).Include(c => c.Editora).Include(c => c.Autor).Include(c => c.Status).Include(c => c.Prioridade).
            OrderBy(c => c.PrioridadeId);

        public IEnumerable<Livro> LivrosFinalizados => _context.Livros.Where(c => c.StatusId == 3).
            Include(c => c.Categoria).Include(c => c.Editora).Include(c => c.Autor).Include(c => c.Status).Include(c => c.Prioridade).
            OrderBy(c => c.PrioridadeId);

        public Livro GetLivroById(int id)
        {
            return _context.Livros.FirstOrDefault(c=> c.LivroId == id);
        }
    }
}
