using ControleLeitura2.Models;

namespace ControleLeitura2.ViewModel
{
    public class LivrosViewModel
    {
        public IEnumerable<Livro> Livros { get; set; }

        public string CategoriaAtual { get; set; }

    }
}
