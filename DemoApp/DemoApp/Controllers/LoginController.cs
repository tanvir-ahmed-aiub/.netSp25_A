using DemoApp.DTOs;
using DemoApp.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Logini
        Demo_F24_AEntities db = new Demo_F24_AEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Index(LoginDTO log)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Username.Equals(log.Username)
                            && u.Password.Equals(log.Password)
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("List", "Student");
                }


            }
            return View(log);

        }
    }
}