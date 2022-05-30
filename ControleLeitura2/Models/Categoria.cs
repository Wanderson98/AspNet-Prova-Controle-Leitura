using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleLeitura2.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="Um nome para categoria deve ser informado")]
        [StringLength(50)]
        [Display(Name = "Nome Categoria")]
        public string CategoriaNome { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}
