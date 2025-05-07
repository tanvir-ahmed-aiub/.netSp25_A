using PMS.Auth;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class DashoboardController : Controller
    {
        private PMS_Sp25_AEntities db = new PMS_Sp25_AEntities();
        // GET: Dashoboard
        [UserAuth]
        public ActionResult HomeUser()
        {
            return View();
        }
        [UserAuth]
        public ActionResult MyOrders() {
            var user = (Login)Session["User"];
            var orders = (from o in db.Orders
                          where o.CusId == user.UserId
                          select o).ToList();
            return View(orders);
        }
        [UserAuth]
        public ActionResult ODetails(int id) {
            var orderD = (from p in db.OrderDetails
                         where p.OId == id
                         select p).ToList();
            return View(orderD);

        }
        [AdminAuth]
        public ActionResult HomeAdmin() {
            var orders = db.Orders.ToList();
            return View(orders);
        }
        [AdminAuth]
        public ActionResult AcceptOrder(int id) {
            var products = (from o in db.OrderDetails
                      where o.OId == id
                      select o).ToList();
            foreach (var item in products)
            {
                var pr = db.Products.Find(item.PId);
                pr.Qty -= item.Qty;
            }
            var order = db.Orders.Find(id);
            order.StatusId = 2;
            db.SaveChanges();

            return RedirectToAction("HomeAdmin");

        }
    }
}