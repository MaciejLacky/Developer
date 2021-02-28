using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Developer.Models.Shop
{
    public class Orders
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}