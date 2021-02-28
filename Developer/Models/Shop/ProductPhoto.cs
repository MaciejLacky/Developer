using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class ProductPhoto
    {
        [Key] 
        public int IdProductPhoto { get; set; }
        public string Url { get; set; }
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }
    }
}