using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleLeitura2.Context;
using ControleLeitura2.Models;
using ControleLeitura2.Repositories.Interfaces;
using ControleLeitura2.ViewModel;

namespace ControleLeitura2.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ControleLeituraContext _context;
        private readonly ILivroRepository _livroRepository;

        public LivrosController(ControleLeituraContext context, ILivroRepository livroRepository)
        {
            _context = context;
            _livroRepository = livroRepository;
        }



        // GET: Livros
        public IActionResult Index(string categoria)
        {
            IEnumerable<Livro> livros;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                livros = _livroRepository.Livros.OrderBy(l => l.LivroId);
                categoriaAtual = "Todos os Livros";
            }
            else
            {
                livros = _livroRepository.Livros.Where(l => l.Categoria.CategoriaNome.Equals(categoria)).
                    OrderBy(l => l.NomeLivro);
                categoriaAtual = categoria;
            }

            var livroViewModel = new LivrosViewModel
            {
                Livros = livros,
                CategoriaAtual = categoriaAtual,

            };

            return View(livroViewModel);
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Livro> livros;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                livros = _livroRepository.Livros.OrderBy(l => l.LivroId);
                categoriaAtual = "Todos os Livros";
            }
            else
            {
                livros = _livroRepository.Livros.Where(l => l.Categoria.CategoriaNome.Equals(categoria)).
                    OrderBy(l => l.NomeLivro);
                categoriaAtual = categoria;
            }

            var livroViewModel = new LivrosViewModel
            {
                Livros = livros,
                CategoriaAtual = categoriaAtual,

            };

            return View(livroViewModel);
        }

        // GET: Livros/Details/5
        public IActionResult Details(int? livroId)
        {
            var livro = _livroRepository.Livros.FirstOrDefault(c => c.LivroId == livroId);
            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorNome");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "EditoraId", "EditoraNome");
            ViewData["PrioridadeId"] = new SelectList(_context.Prioridades, "PrioridadeId", "PrioridadeNome");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroId,NomeLivro,ResumoLivro,AnoLancamento,LivroCapaCaminho,IsFavorito,CategoriaId,AutorId,EditoraId,StatusId,PaginaAtual,PrioridadeId,Nota")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorNome", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "EditoraId", "EditoraNome", livro.EditoraId);
            ViewData["PrioridadeId"] = new SelectList(_context.Prioridades, "PrioridadeId", "PrioridadeNome", livro.PrioridadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", livro.StatusId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorNome", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "EditoraId", "EditoraNome", livro.EditoraId);
            ViewData["PrioridadeId"] = new SelectList(_context.Prioridades, "PrioridadeId", "PrioridadeNome", livro.PrioridadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", livro.StatusId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edits(int id, [Bind("LivroId,NomeLivro,ResumoLivro,AnoLancamento,LivroCapaCaminho,IsFavorito,CategoriaId,AutorId,EditoraId,StatusId,PaginaAtual,PrioridadeId,Nota")] Livro livro)
        {
            if (id != livro.LivroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorNome", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "EditoraId", "EditoraNome", livro.EditoraId);
            ViewData["PrioridadeId"] = new SelectList(_context.Prioridades, "PrioridadeId", "PrioridadeNome", livro.PrioridadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", livro.StatusId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .Include(l => l.Editora)
                .Include(l => l.Prioridade)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LivroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Deletes")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livros == null)
            {
                return Problem("Entity set 'ControleLeituraContext.Livros'  is null.");
            }
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return _context.Livros.Any(e => e.LivroId == id);
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorNome", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "EditoraId", "EditoraNome", livro.EditoraId);
            ViewData["PrioridadeId"] = new SelectList(_context.Prioridades, "PrioridadeId", "PrioridadeNome", livro.PrioridadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", livro.StatusId);
            return View(livro);
        }

        public async Task<IActionResult> Finalizar(int id, [Bind("LivroId,NomeLivro,ResumoLivro,AnoLancamento,LivroCapaCaminho,IsFavorito,CategoriaId,AutorId,EditoraId,StatusId,PaginaAtual,PrioridadeId,Nota")] Livro livro)
        {
            if (id != livro.LivroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "AutorNome", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "EditoraId", "EditoraNome", livro.EditoraId);
            ViewData["PrioridadeId"] = new SelectList(_context.Prioridades, "PrioridadeId", "PrioridadeNome", livro.PrioridadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", livro.StatusId);
            return View(livro);
        }
    }
}
