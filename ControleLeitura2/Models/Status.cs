using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleLeitura2.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Um status deve ser inforamdo")]
        [StringLength(50)]
        [Display(Name = "Status Leitura")]
        public string NomeStatus { get; set; }
        public ICollection<Livro> Livros { get; set; }


    }
}
