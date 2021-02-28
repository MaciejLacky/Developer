using Developer.Models;
using Developer.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developer.Controllers
{
    public class ShopController : Controller
    {
        private DeveloperContext db = new DeveloperContext();
        public ActionResult Index(int page = 1, int sortowanie = 1)
        {
            int pageSize = 4;
            var products = (from t in db.Products
                            select new ProductViewModel
                            {
                                Name = t.Name,
                                Description = t.Description,
                                VIPProduct = t.VIPProduct,
                                ProductSale = t.ProductSale,
                                Price = t.Price,
                                IdProduct = t.IdProduct,
                                Photos = t.ProductPhoto.Select(x => x.Url),
                                Quantity = t.ProductQuantity.Sum(x => x.Quantity)
                            }).ToList();

            int liczbaZamowionych = 0;
            foreach (var t in products)
            {
                if (db.OrderDetailPositions.Any(x => x.IdProduct == t.IdProduct))
                {
                    liczbaZamowionych = (from z in db.OrderDetailPositions where z.IdProduct == t.IdProduct select z.Quantity).Sum();
                    t.Quantity = t.Quantity - liczbaZamowionych;
                }
            }
            List<SelectListItem> sortowanieLista = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Nazwa od A do Z",
                    Value = "1",
                    Selected = (sortowanie == 1? true : false)
                },
                 new SelectListItem
                {
                    Text = "Nazwa od Z do A",
                    Value = "2",
                    Selected = (sortowanie == 2? true : false)
                },
                 new SelectListItem
                {
                    Text = "Ceny rosnąco",
                    Value = "3",
                    Selected = (sortowanie == 3? true : false)
                },
                  new SelectListItem
                {
                    Text = "Ceny malejąco",
                    Value = "4",
                    Selected = (sortowanie == 4? true : false)
                },
            };
            ViewBag.Sortowanie = sortowanie;
            ViewBag.Sortowanie = sortowanieLista;
            switch (sortowanie)
            {
                case 1:
                    products = products.OrderBy(x => x.Name).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(x => x.Name).ToList();
                    break;
                case 3:
                    products = products.OrderBy(x => x.Price).ToList();
                    break;
                case 4:
                    products = products.OrderByDescending(x => x.Price).ToList();
                    break;


                default:
                    break;
            }
            return View(products.ToPagedList(page, pageSize));
        }

    
        public ActionResult Details(int id)
        {
            ProductViewModel product =
          (from t in db.Products
           where t.IdProduct == id
           select new ProductViewModel
           {
               Name = t.Name,
               Description = t.Description,
               VIPProduct = t.VIPProduct,
               ProductSale = t.ProductSale,
               Price = t.Price,
               IdProduct = t.IdProduct,
               Photos = t.ProductPhoto.Select(x => x.Url),
               Quantity = t.ProductQuantity.Sum(x => x.Quantity)
           }).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            int liczbaZamowionych = 0; 
            if (db.OrderDetailPositions.Any(x => x.IdProduct == product.IdProduct)) 
            { liczbaZamowionych = (from z in db.OrderDetailPositions 
                                   where z.IdProduct == product.IdProduct 
                                   select z.Quantity).Sum(); }
            product.Quantity = product.Quantity - liczbaZamowionych;

            return View(product);
        }


    }
}