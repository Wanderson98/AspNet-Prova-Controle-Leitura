using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleLeitura2.Models;

[Table("Prioridade")]
public class Prioridade
{
    public int PrioridadeId { get; set; }
    [Required(ErrorMessage = "Um nome a prioridade deve ser informada")]
    [StringLength(50, ErrorMessage = "Deve ter no máximo 50 caracteres")]
    public string PrioridadeNome { get; set; }

    public IEnumerable<Livro> Livros { get; set; }
}

