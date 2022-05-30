using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleLeitura2.Models
{
    [Table("Editoras")]
    public class Editora
    {
        [Key]
        public int EditoraId { get; set; }
        [Required(ErrorMessage = "Um nome deve ser informado")]
        [StringLength(50, ErrorMessage = "Digite o nome válido")]
        [Display(Name = "Editora")]
        public string EditoraNome{ get; set; }

        [Required(ErrorMessage ="Um CNPJ deve ser informado")]
        [StringLength (18, MinimumLength = 18, ErrorMessage = "Digite um CNPJ válido")]
        [RegularExpression(@"^[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}$", ErrorMessage = "CNPJ Inválido")]
        [Display(Name = "CNPJ")]
        public string EditoraCnpj { get; set; }
        [Required(ErrorMessage = "Um Email deve ser informado")]
        [StringLength(50)]
        [Display(Name = "Email Editora")]
        [DataType(DataType.EmailAddress)]
        public string EditoraEmail { get; set; }
        [Required(ErrorMessage = "Um telefone deve ser informado")]
        [RegularExpression(@"^(.?[0-9]{2}).? [0-9]{5}-.?[0-9]{4}", ErrorMessage = "Telefone Inválido (DDD) 99999-9999")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Digite um Telefone válido")]
        [Display(Name = "Telefone Editora")]
        public string TelefoneEditora { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}
