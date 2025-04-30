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

        
    }
}