using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Developer.Models;
using Developer.Models.CMS;

namespace Developer.Controllers.PanelCMS
{
    public class LogBuildingsController : Controller
    {
        private DeveloperContext db = new DeveloperContext();

        // GET: LogBuildings
        public ActionResult Index()
        {
            return View(db.LogBuildings.ToList());
        }

        // GET: LogBuildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogBuilding logBuilding = db.LogBuildings.Find(id);
            if (logBuilding == null)
            {
                return HttpNotFound();
            }
            return View(logBuilding);
        }

        // GET: LogBuildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogBuildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLog,Title,Content,Position")] LogBuilding logBuilding)
        {
            if (ModelState.IsValid)
            {
                db.LogBuildings.Add(logBuilding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logBuilding);
        }

        // GET: LogBuildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogBuilding logBuilding = db.LogBuildings.Find(id);
            if (logBuilding == null)
            {
                return HttpNotFound();
            }
            return View(logBuilding);
        }

        // POST: LogBuildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLog,Title,Content,Position")] LogBuilding logBuilding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logBuilding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logBuilding);
        }

        // GET: LogBuildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogBuilding logBuilding = db.LogBuildings.Find(id);
            if (logBuilding == null)
            {
                return HttpNotFound();
            }
            return View(logBuilding);
        }

        // POST: LogBuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogBuilding logBuilding = db.LogBuildings.Find(id);
            db.LogBuildings.Remove(logBuilding);
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
