using Developer.Models.CMS;
using Developer.Models.Messages;
using Developer.Models.Shop;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Developer.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<DeveloperContext>
    {
        private string _description = "The standard chunk of Lorem Ipsum used since the 1500s is " +
            "reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum " +
            "by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.";
        protected override void Seed(DeveloperContext context)
        {
            var product = new List<Product>
            {
                new Product {Name = "Mieszkanie 1A", Price = 450000, Description = _description, VIPProduct = true, ProductSale = false },
                new Product {Name = "Mieszkanie 1B", Price = 650000, Description = _description, VIPProduct = false, ProductSale = false },
                new Product {Name = "Mieszkanie 1C", Price = 800000, Description = _description, VIPProduct = false, ProductSale = false },
                new Product {Name = "Mieszkanie 1D", Price = 950000, Description = _description, VIPProduct = false, ProductSale = true },
                new Product {Name = "Mieszkanie 2A", Price = 550000, Description = _description, VIPProduct = false, ProductSale = false },
                new Product {Name = "Mieszkanie 2B", Price = 820000, Description = _description, VIPProduct = false, ProductSale = true },
                new Product {Name = "Mieszkanie 2C", Price = 930000, Description = _description, VIPProduct = false, ProductSale = false },
                new Product {Name = "Mieszkanie 2D", Price = 650000, Description = _description, VIPProduct = true, ProductSale = false },
                new Product {Name = "Mieszkanie 3A", Price = 430000, Description = _description, VIPProduct = false, ProductSale = false },
                new Product {Name = "Mieszkanie 3B", Price = 820000, Description = _description, VIPProduct = false, ProductSale = true },
                new Product {Name = "Mieszkanie 3C", Price = 980000, Description = _description, VIPProduct = false, ProductSale = false },
                new Product {Name = "Mieszkanie 3D", Price = 1250000, Description = _description, VIPProduct = true, ProductSale = false },


            }.ToList();
            foreach (var a in product)
            {
                context.Products.Add(a);
            }

            var photos = new List<ProductPhoto>
            {
                new ProductPhoto {Url ="/Content/Photo/blok.jpg", IdProduct = 1},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1.jpg", IdProduct = 1},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1Salon.jpg", IdProduct = 1},
                new ProductPhoto {Url ="/Content/Photo/plaMieszkania1.jpg", IdProduct = 1},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1Salon.jpg", IdProduct = 2},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1.jpg", IdProduct = 2},
                new ProductPhoto {Url ="/Content/Photo/plaMieszkania1.jpg", IdProduct = 2},
                new ProductPhoto {Url ="/Content/Photo/plaMieszkania1.jpg", IdProduct = 3},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1.jpg", IdProduct = 3},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1Salon.jpg", IdProduct = 4},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1.jpg", IdProduct = 4},
                new ProductPhoto {Url ="/Content/Photo/plaMieszkania1.jpg", IdProduct = 4},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2blok.jpg", IdProduct = 5},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2dzienny.jpg", IdProduct = 5},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2plan.jpg", IdProduct = 5},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2dzienny.jpg", IdProduct = 6},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2plan.jpg", IdProduct = 6},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1Salon.jpg", IdProduct = 7},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1.jpg", IdProduct = 7},
                new ProductPhoto {Url ="/Content/Photo/plaMieszkania1.jpg", IdProduct = 7},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2blok.jpg", IdProduct = 8},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2dzienny.jpg", IdProduct = 8},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2plan.jpg", IdProduct = 8},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2dzienny.jpg", IdProduct = 9},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2plan.jpg", IdProduct = 9},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1Salon.jpg", IdProduct = 10},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie1.jpg", IdProduct = 10},
                new ProductPhoto {Url ="/Content/Photo/plaMieszkania1.jpg", IdProduct = 11},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2blok.jpg", IdProduct = 11},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2dzienny.jpg", IdProduct = 11},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2plan.jpg", IdProduct = 12},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2dzienny.jpg", IdProduct = 12},
                new ProductPhoto {Url ="/Content/Photo/mieszkanie2plan.jpg", IdProduct = 12},
            }.ToList();
            foreach (var a in photos)
            {
                context.ProductPhotos.Add(a);
            }
            var quantity = new List<ProductQuantity>
            {
                new ProductQuantity{ IdProduct = 1, Quantity = 1, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 2, Quantity = 2, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 3, Quantity = 1, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 4, Quantity = 2, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 5, Quantity = 1, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 6, Quantity = 1, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 7, Quantity = 3, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 8, Quantity = 1, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 9, Quantity = 1, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 10, Quantity = 2, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 11, Quantity = 2, DateCreate = DateTime.Now},
                new ProductQuantity{ IdProduct = 12, Quantity = 1, DateCreate = DateTime.Now},

            }.ToList();

            foreach (var a in quantity)
            {
                context.ProductQuantities.Add(a);
            }

            var logBuldings = new List<LogBuilding>
            {
                new LogBuilding{ Title="2021.01.01 Etap3 zakończono", Content = _description, Position = 1},
                new LogBuilding{ Title="2020.01.01 Etap2 zakończono", Content = _description, Position = 2},

            }.ToList();
            foreach (var a in logBuldings)
            {
                context.LogBuildings.Add(a);
            }

            var messages = new List<MessagesFromClient>
            {
                new MessagesFromClient { ContentMessage = _description, Email="lacky@lacky.pl", Name="Maciej Łącki", Phone="65895324", TitleMessage="Zapytanie ofertowe mieszkanie 1A"}

            }.ToList();

            foreach (var a in messages)
            {
                context.MessagessFromClient.Add(a);
            }
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var rolaAdmin = new IdentityRole { Name = "Admin" };
            var rolaClient = new IdentityRole { Name = "Klienci" }; 
            roleManager.Create(rolaClient);
            roleManager.Create(rolaAdmin);
            context.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            string haslo = "admin123";
            string email = "admin@op.pl";
            ApplicationUser uzytkownik = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
            };
            if (userManager.Create(uzytkownik, haslo).Succeeded)
            {
                userManager.AddToRole(uzytkownik.Id, "Admin");
                Client client = new Client()
                {
                    Email = uzytkownik.Email,
                    FirstName = "Admin",
                    LastName = "Lacki",
                    UserId = uzytkownik.Id
                };
                context.Client.Add(client);
                context.SaveChanges();
            }
            context.SaveChanges();

        }

    }
}