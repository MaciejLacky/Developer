using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Developer.Models.CMS
{
    public class LogBuilding
    {
        [Key]
        public int IdLog{ get; set; }
        [Required(ErrorMessage = "Tytuł wpisu do dziennika")]
        [MaxLength(200, ErrorMessage = "Tytuł powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        [Display(Name = "Pozycja")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Position { get; set; }
    }
}