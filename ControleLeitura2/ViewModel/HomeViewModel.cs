using ControleLeitura2.Models;

namespace ControleLeitura2.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Livro> LivrosFavoritos { get; set; }
        public IEnumerable<Livro> LivrosLendoAgora { get; set; }
        public IEnumerable<Livro> LivrosParaLer { get; set; }
        public IEnumerable<Livro> LivrosFinalizados { get; set; }
    }
}
