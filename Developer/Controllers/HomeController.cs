using Developer.Models;
using Developer.Models.CMS;
using Developer.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Developer.Models;
using Developer.Models.Shop;

namespace Developer.Controllers
{
    public class HomeController : Controller
    {
        private DeveloperContext db = new DeveloperContext();
       
        public ActionResult _LogBuilding()
        {
            List<LogBuilding> logList = db.LogBuildings.OrderBy(x => x.Position).ToList();
            return PartialView(logList);
        }
        public ActionResult OurWork()
        {
            return View();
        }
        public ActionResult _ProductSale()
        {
            List<Product> productSale = (
                from sale in db.Products
                where sale.ProductSale == true
                select sale
                ).Take(1).ToList();
            return PartialView(productSale);
        }
        public ActionResult _ProductVip()
        {
            List<Product> productSale = (
                from sale in db.Products
                where sale.VIPProduct == true
                select sale
                ).Take(1).ToList();
            return PartialView(productSale);
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}