using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class OrderDetailPosition
    {
        [Key]
        public int IdOrderDetalPosition { get; set; }
        public int IdProduct { get; set; }
        
        public virtual Product Product { get; set; }
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        [Display(Name = "Wartość")]
        public decimal Amount { get; set; }
        [Display(Name = "Numer zamówienia")]
        public int IdOrderDetail { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}