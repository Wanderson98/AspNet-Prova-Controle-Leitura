using ControleLeitura2.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleLeitura2.Context
{
    public class ControleLeituraContext : DbContext
    {
        public ControleLeituraContext(DbContextOptions<ControleLeituraContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
