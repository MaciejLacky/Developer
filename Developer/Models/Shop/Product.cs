using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Nazwa towaru jest wymagana.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Cena towaru jest wymagana.")]
        [DataType(DataType.Currency, ErrorMessage = "Wartość w polu 'Cena' jest nieprawidłowa. Wartość musi być liczbą.")]
        public decimal Price { get; set; }
        [Display(Name = "VIP Towar")]
        public bool VIPProduct { get; set; }
        [Display(Name = "Towar promocyjny")]
        public bool ProductSale { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhoto { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantity { get; set; }
    }
}