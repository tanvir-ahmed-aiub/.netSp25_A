using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public static Product Convert(ProductDTO p) {
            return new Product() { 
                Id = p.Id,
                Name = p.Name,
                Qty = p.Qty,
                Price = p.Price,
                CId = p.CId
            };
        }
        public static ProductDTO Convert(Product p)
        {
            return new ProductDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Qty = p.Qty,
                Price = p.Price,
                CId = p.CId
            };
        }
        public static List<ProductDTO> Convert(List<Product> list) { 
            var products = new List<ProductDTO>();
            foreach (var product in list) { 
                products.Add(Convert(product));
            }
            return products;
        }
    }
}