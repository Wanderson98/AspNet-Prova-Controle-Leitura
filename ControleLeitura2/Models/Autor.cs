using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleLeitura2.Models
{
    [Table("Autores")]
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        [Required(ErrorMessage = "Um nome deve ser informado")]
        [StringLength(100)]
        [Display(Name = "Nome Autor")]
        public string AutorNome { get; set; }
        [Required(ErrorMessage = "Uma nacionalidade deve ser informada")]
        [StringLength (50)]
        [Display(Name = "Nacionalidade")]
        public string AutorNacionalidade { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}
