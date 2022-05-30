using ControleLeitura2.Models;
using ControleLeitura2.Repositories.Interfaces;
using ControleLeitura2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleLeitura2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILivroRepository _livroRepository;

        public HomeController(ILogger<HomeController> logger, ILivroRepository livroRepository)
        {
            _logger = logger;
            _livroRepository = livroRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel {
                LivrosFavoritos = _livroRepository.LivrosFavoritos,
                LivrosFinalizados = _livroRepository.LivrosFinalizados,
                LivrosLendoAgora = _livroRepository.LivrosLendoAgora,
                LivrosParaLer = _livroRepository.LivrosParaLer,
           
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}