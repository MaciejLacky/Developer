using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "VIP Produkt")]
        public bool VIPProduct { get; set; }
        [Display(Name = "Promocja")]
        public bool ProductSale { get; set; }
        public IEnumerable<string> Photos { get; set; }
        public decimal Quantity { get; set; }
    }
}