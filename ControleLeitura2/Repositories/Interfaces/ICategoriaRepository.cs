using ControleLeitura2.Models;

namespace ControleLeitura2.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
