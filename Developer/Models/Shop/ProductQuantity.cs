using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class ProductQuantity
    {
        [Key] 
        public int IdProductQuantity { get; set; }
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
    }
}