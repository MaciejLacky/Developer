using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class Client
    {
        [Key] public int IdClient { get; set; }
        [Required(ErrorMessage = "Pole imię jest wymagane.")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pole e-mail jest wymagane.")]
        [EmailAddress(ErrorMessage = "Zły format adresu e-mail.")]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}