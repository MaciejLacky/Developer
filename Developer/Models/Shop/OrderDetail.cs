using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class OrderDetail
    {
        [Key]
        [Display(Name = "Nr zamówienia")]
        public int IdZamowienie { get; set; }
        public int IdClient { get; set; }
        public virtual Client Client { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Adres jest wymagany.")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Telefon jest wymagany.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email jest wymagany.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Data zamówienia")]
        public DateTime DateOrder { get; set; }
        public virtual ICollection<OrderDetailPosition> OrderDetailPosition { get; set; }
    }
}