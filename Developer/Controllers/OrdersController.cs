using Developer.Models;
using Developer.Models.Shop;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developer.Controllers
{
    public class OrdersController : Controller
    {
        private DeveloperContext db = new DeveloperContext();
        private const string KoszykSesjaKlucz = "koszykSesja";
        public ActionResult Index()
        {
            List<Orders> pozycjeKoszyka = new List<Orders>();

            if (Session[KoszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as
                    List<Orders>;
            }
            return View(pozycjeKoszyka);
        }
        [HttpPost]
        public ActionResult DodajPozycjeDoKoszyka(int idTowar, int iloscTowaru)
        {
            List<Orders> pozycjeKoszyka = new List<Orders>();
            if (Session[KoszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<Orders>;
            }
            if (pozycjeKoszyka.Any(x => x.Product.IdProduct == idTowar))
            {
                Orders pozycjaWKoszyku = pozycjeKoszyka.Find(x => x.Product.IdProduct == idTowar);
                int stanTowary = pozycjaWKoszyku.Product.ProductQuantity.Sum(x => x.Quantity);
                if (stanTowary >= (pozycjaWKoszyku.Quantity + iloscTowaru))
                {
                    pozycjaWKoszyku.Quantity += iloscTowaru;
                    pozycjaWKoszyku.Amount = pozycjaWKoszyku.Quantity * pozycjaWKoszyku.Product.Price;
                }

            }
            else
            {
                Product towar = db.Products.FirstOrDefault(x => x.IdProduct == idTowar);
                if (towar == null)
                {
                    return HttpNotFound();
                }
                int stanTowary = towar.ProductQuantity.Sum(x => x.Quantity);
                if (stanTowary >= iloscTowaru)
                {
                    Orders nowaPozycja = new Orders()
                    {
                        Quantity = iloscTowaru,
                        Amount = towar.Price * iloscTowaru,
                        Product = towar,
                    };
                    pozycjeKoszyka.Add(nowaPozycja);

                }
            }
            Session[KoszykSesjaKlucz] = pozycjeKoszyka;
            return RedirectToAction("Index");

        }
        public ActionResult UsunPozycjeZKoszyka(int idTowar)
        {
            List<Orders> pozycjeKoszyka = new List<Orders>();
            if (Session[KoszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<Orders>;
            }
            pozycjeKoszyka = pozycjeKoszyka.Where(x => x.Product.IdProduct != idTowar).ToList();
            Session[KoszykSesjaKlucz] = pozycjeKoszyka;
            return RedirectToAction("Index");
        }

        public ActionResult DaneZamowienia()
        {
            //string userId = User.Identity.GetUserId();
            Client client =
            (from h in db.Client
             //where h.UserId == userId
             select h).FirstOrDefault();
            OrderDetail order = new OrderDetail();
            order.Email = client.Email;
            order.FirstName = client.FirstName;
            order.LastName = client.LastName;
            return View(order);
        }
        [HttpPost]
        public ActionResult DaneZamowienia(OrderDetail zamowienie)
        {
            if (ModelState.IsValid)
            {
                List<Orders> pozycjeKoszyka = new List<Orders>();
                if (Session[KoszykSesjaKlucz] != null)
                {
                    pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<Orders>;
                }
                List<OrderDetailPosition> pozycjeZamowienia = new List<OrderDetailPosition>();
                foreach (var pozycja in pozycjeKoszyka)
                {
                    pozycjeZamowienia.Add(new OrderDetailPosition
                    {
                        Price = pozycja.Product.Price,
                        IdProduct = pozycja.Product.IdProduct,
                        Quantity = pozycja.Quantity,
                        Amount = pozycja.Quantity * pozycja.Product.Price,
                    });
                }
                //string userId = User.Identity.GetUserId();
                Client handlowiec = (from h in db.Client 
                                     //where h.UserId == userId 
                                     select h).FirstOrDefault();
                zamowienie.DateOrder = DateTime.Now;
                zamowienie.IdClient = 1; // handlowiec.IdClient;
                zamowienie.OrderDetailPosition = pozycjeZamowienia;
                db.OrderDetails.Add(zamowienie); db.SaveChanges();
                Session[KoszykSesjaKlucz] = null;
                return RedirectToAction("PotwierdzenieZamowienia");
            }
            return View(zamowienie);
        }
        public ActionResult PotwierdzenieZamowienia() 
        { 
            return View(); 
        }
        public ActionResult _MiniKoszyk()
        {
            List<Orders> pozycjeKoszyka = new List<Orders>();
            if (Session[KoszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<Orders>;
            }
            decimal wartoscKoszyka = 0;
            if (pozycjeKoszyka != null && pozycjeKoszyka.Count > 0)
            {
                wartoscKoszyka = pozycjeKoszyka.Sum(x => x.Amount);
            }
            ViewBag.WartoscKoszyka = wartoscKoszyka;
            return PartialView();
        }
    }
}