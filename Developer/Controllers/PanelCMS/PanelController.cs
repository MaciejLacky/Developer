using Developer.Models;
using Developer.Models.Messages;
using Developer.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developer.Controllers.PanelCMS
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private DeveloperContext db = new DeveloperContext();
        public ActionResult _MessagesFromClient()
        {
            List<MessagesFromClient> logList = db.MessagessFromClient.Take(2).OrderByDescending(x => x.IdMessage).ToList();
            return PartialView(logList);
        }
        public ActionResult _OrdersFromClient()
        {
            List<OrderDetail> orders = db.OrderDetails.OrderBy(x => x.IdZamowienie).ToList();
            return PartialView(orders);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}