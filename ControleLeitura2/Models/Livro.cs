
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ControleLeitura2.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }
        [Required(ErrorMessage = "O nome do livro deve ser informado")]
        [StringLength(50)]
        [Display(Name = "Nome do Livro")]
        public string NomeLivro { get; set; }
        [Required(ErrorMessage = "Um resumo do livro deve ser informado")]
        [StringLength(500)]
        [Display(Name = "Resumo do Livro")]
        public string ResumoLivro { get; set; }
        [Required(ErrorMessage = "O ano de lançamento deve ser informado")]
        [Display(Name = "Ano Lançamento")]
        
        public int AnoLancamento { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Insira o caminho da imagem")]
        [Display(Name = "Caminho Capa Livro")]
        public string LivroCapaCaminho { get; set; }

        [Display(Name = "Livro Favorito")]
        public bool IsFavorito { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        [Display(Name = "Editora")]
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        [Display(Name = "Página Atual")]
        public int? PaginaAtual { get; set; }
        [Display(Name = "Prioridade")]
        public int PrioridadeId { get; set; }
        public Prioridade Prioridade { get; set; }
        [Display(Name = "Nota do Livro")]
        [Range(0,10, ErrorMessage = "A nota deve ser entre 0 a 10")]
        public double? Nota { get; set; }
    }
}