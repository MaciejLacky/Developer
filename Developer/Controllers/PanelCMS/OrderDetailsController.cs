using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Developer.Models;
using Developer.Models.Shop;

namespace Developer.Controllers.PanelCMS
{
    public class OrderDetailsController : Controller
    {
        private DeveloperContext db = new DeveloperContext();
        public decimal _amount;       
        // GET: OrderDetails
        public ActionResult Index()
        {
            var orderDetails = db.OrderDetails.Include(o => o.Client).OrderByDescending(x =>x.IdZamowienie);
           
            return View(orderDetails.ToList());
        }
        public ActionResult _OrderDetailPositionFromClient(int? id)
        {
            List<OrderDetailPosition> logList = db.OrderDetailPositions.Where(x => x.OrderDetail.IdZamowienie == id).ToList();
            _amount = 0;
            foreach (var item in logList)
            {
                _amount += item.Amount; 
            }
            ViewData["Amount"] = _amount;
            return PartialView(logList);
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            _OrderDetailPositionFromClient(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }
       
        

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "FirstName");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZamowienie,IdClient,FirstName,LastName,Adres,Phone,Email,DateOrder")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "FirstName", orderDetail.IdClient);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "FirstName", orderDetail.IdClient);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZamowienie,IdClient,FirstName,LastName,Adres,Phone,Email,DateOrder")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "FirstName", orderDetail.IdClient);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            IQueryable< OrderDetailPosition> orderDetailPosition = db.OrderDetailPositions.Where(x => x.OrderDetail.IdZamowienie == orderDetail.IdZamowienie);
            foreach (var item in orderDetailPosition)
            {
                db.OrderDetailPositions.Remove(item);
                
            }
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
