using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Developer.Models;
using Developer.Models.Messages;

namespace Developer.Controllers.PanelCMS
{
    public class MessagesFromClientsController : Controller
    {
        private DeveloperContext db = new DeveloperContext();

        // GET: MessagesFromClients
        public ActionResult Index()
        {
            return View(db.MessagessFromClient.ToList());
        }
       

        // GET: MessagesFromClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessagesFromClient messagesFromClient = db.MessagessFromClient.Find(id);
            if (messagesFromClient == null)
            {
                return HttpNotFound();
            }
            return View(messagesFromClient);
        }

        // GET: MessagesFromClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessagesFromClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMessage,TitleMessage,Name,ContentMessage,Email,Phone")] MessagesFromClient messagesFromClient)
        {
            if (ModelState.IsValid)
            {
                db.MessagessFromClient.Add(messagesFromClient);
                db.SaveChanges();
               
                return Redirect("~/");
            }

            return View(messagesFromClient);
        }

        // GET: MessagesFromClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessagesFromClient messagesFromClient = db.MessagessFromClient.Find(id);
            if (messagesFromClient == null)
            {
                return HttpNotFound();
            }
            return View(messagesFromClient);
        }

        // POST: MessagesFromClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMessage,TitleMessage,Name,ContentMessage,Email,Phone")] MessagesFromClient messagesFromClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messagesFromClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messagesFromClient);
        }

        // GET: MessagesFromClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessagesFromClient messagesFromClient = db.MessagessFromClient.Find(id);
            if (messagesFromClient == null)
            {
                return HttpNotFound();
            }
            return View(messagesFromClient);
        }

        // POST: MessagesFromClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessagesFromClient messagesFromClient = db.MessagessFromClient.Find(id);
            db.MessagessFromClient.Remove(messagesFromClient);
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
