using Developer.Models.CMS;
using Developer.Models.Messages;
using Developer.Models.Shop;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Developer.Models
{
    public class DeveloperContext : IdentityDbContext<ApplicationUser>
    {
        public DeveloperContext(): base("name=DeveloperContext")
        {

        }
        public static DeveloperContext Create()
        {
            return new DeveloperContext();
        }

        public DbSet<LogBuilding> LogBuildings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<MessagesFromClient> MessagessFromClient { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetailPosition> OrderDetailPositions { get; set; }
    }
}