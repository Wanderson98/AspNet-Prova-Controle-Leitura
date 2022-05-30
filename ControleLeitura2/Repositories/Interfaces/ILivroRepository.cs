using ControleLeitura2.Models;

namespace ControleLeitura2.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> Livros { get; }  
        IEnumerable<Livro> LivrosFavoritos { get; }  
        IEnumerable<Livro> LivrosLendoAgora { get; }  
        IEnumerable<Livro> LivrosParaLer { get; }  
        IEnumerable<Livro> LivrosFinalizados { get; }  


        Livro GetLivroById(int id);

    }
}
