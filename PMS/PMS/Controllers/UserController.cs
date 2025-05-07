using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class UserController : Controller
    {
        private PMS_Sp25_AEntities db = new PMS_Sp25_AEntities();
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(CustomerDTO cs)
        {
            //if (ModelState.IsValid)
            //{
                var data = Convert(cs);
                data.CreatedAt = DateTime.Now;
                db.Customers.Add(data);
                db.SaveChanges();
                var login = new Login()
                {
                    Username = data.Email,
                    Password = data.Password,
                    UserId = data.Id,
                    UserType = "Customer"

                };
                db.Logins.Add(login);
                db.SaveChanges();
                TempData["Msg"] = "Registration Successfull";
                TempData["Class"] = "success";
                return RedirectToAction("Login");
           // }
            //return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UName, string Pass) {
            var user = (from u in db.Logins
                        where u.Username.Equals(UName) &&
                        u.Password.Equals(Pass)
                        select u).SingleOrDefault();
            if (user != null) {
                Session["User"] = user;
                if (TempData["RC"] != null)
                {
                    return RedirectToAction(TempData["RA"].ToString(), TempData["RC"].ToString());
                }
                else if (user.UserType.Equals("Customer"))
                {
                    return RedirectToAction("HomeUser", "Dashoboard");
                }
                else if (user.UserType.Equals("Admin")) {
                    return RedirectToAction("HomeAdmin", "Dashoboard");
                }   
            }
            TempData["Msg"] = "Username or password invalid";
            TempData["Class"] = "danger";
            return View();
        }


        public static CustomerDTO Convert(Customer c)
        {
            return new CustomerDTO()
            {
                Name = c.Name,
                Id = c.Id,
                Password = c.Password,
                Address = c.Address,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                UpdatedAt = c.UpdatedAt,
                UpdatedBy = c.UpdatedBy,
                Email = c.Email,

            };


        }
        public static Customer Convert(CustomerDTO c)
        {
            return new Customer()
            {
                Name = c.Name,
                Id = c.Id,
                Password = c.Password,
                Address = c.Address,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                UpdatedAt = c.UpdatedAt,
                UpdatedBy = c.UpdatedBy,
                Email = c.Email,

            };
        }
        public static List<CustomerDTO> Convert(List<Customer> list)
        {
            var data = new List<CustomerDTO>();
            foreach (var item in list)
            {
                data.Add(Convert(item));
            }
            return data;
        }

    }
}