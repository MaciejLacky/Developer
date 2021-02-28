using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Developer.Models.Messages
{
    public class MessagesFromClient
    {
        [Key]
        public int IdMessage { get; set; }

        [Required(ErrorMessage = "Tytuł wpisu do dziennika")]
        [MaxLength(200, ErrorMessage = "Tytuł powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł")]
        public string TitleMessage { get; set; }

        [Display(Name = "Imię i Nazwisko")]
        [MaxLength(100, ErrorMessage = "Numer max 100 znaków")]
        public string Name { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ContentMessage { get; set; }

        [Display(Name = "Email")]
        [MaxLength(200, ErrorMessage = "Tytuł powinien zawierać max 200 znaków")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [MaxLength(30, ErrorMessage = "Numer max 30 znaków")]
        public string Phone { get; set; }
    }
}