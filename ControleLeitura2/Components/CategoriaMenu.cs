using ControleLeitura2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLeitura2.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaMenu(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _repository.Categorias.OrderBy(p => p.CategoriaNome);
            return View(categorias);
        }
    }
}
