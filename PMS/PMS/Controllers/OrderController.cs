using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class OrderController : Controller
    {
        private PMS_Sp25_AEntities db = new PMS_Sp25_AEntities();
        // GET: Order
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(ProductController.Convert(data));
        }
        public ActionResult AddtoCart(int id) {
            List<ProductDTO> cart = null;
            if (Session["Cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else {
                cart = (List<ProductDTO>)Session["Cart"];
            }
            var pr = db.Products.Find(id);
            var p = ProductController.Convert(pr);
            p.Qty = 1;
            cart.Add(p);
            Session["Cart"] = cart;
            TempData["Msg"] = "Product " + p.Name + " added to cart";
            return RedirectToAction("Index");
        }
        public ActionResult Cart() {
            if (Session["Cart"] != null) {
                var data = (List < ProductDTO >) Session["Cart"];
                return View(data);
            }
            TempData["Msg"] = "Cart is empty";
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public ActionResult PlaceOrder(decimal Total) {
            if (Session["User"] == null)
            {
                TempData["Msg"] = "Please login to place order";
                TempData["Class"] = "danger";
                TempData["RC"] = "Order";
                TempData["RA"] = "Cart";
                return RedirectToAction("Login", "User");
            }
            else {
                var user = (Login)Session["User"];
                var order = new Order() { 
                    StatusId = 1,
                    Time = DateTime.Now,
                    Total = Total,
                    CusId = user.Id,
                };
                db.Orders.Add(order);
                db.SaveChanges();
                var cart = (List<ProductDTO>)Session["Cart"];
                foreach (var p in cart) {
                    var od = new OrderDetail() { 
                        PId = p.Id,
                        Qty = p.Qty,
                        Price = p.Price,
                        OId = order.Id
                       
                    };
                    db.OrderDetails.Add(od);
                }
                db.SaveChanges();
                TempData["Msg"] = "Order Placed Successfully";
                Session["Cart"] = null;
                return RedirectToAction("Index");
            }
            
            //
            //
            //
            //

        }
        public ActionResult CartDec(int id)
        {
            var cart = (List<ProductDTO>)Session["Cart"];
            var pr = (from p in cart where p.Id == id select p).SingleOrDefault();
            pr.Qty--;
            return RedirectToAction("Cart");
        }
        public ActionResult CartInc(int id)
        {
            var cart = (List<ProductDTO>)Session["Cart"];
            var pr = (from p in cart where p.Id == id select p).SingleOrDefault();
            pr.Qty++;
            return RedirectToAction("Cart");
        }


    }
}