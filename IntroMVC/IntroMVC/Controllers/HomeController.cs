
using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IntroMVC.Controllers
{
    public class HomeController : Controller
    {
        private object course;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //return Redirect("https://www.aiub.edu/contact");
            return RedirectToAction("About","Home");
        }
        public ActionResult MyPage() {
            return View();
        }
        public ActionResult Students() {
            var s1 = new Student() { 
                Id = 1,
                Name = "S1"
            };
            var s2 = new Student() { 
                Id = 2,
                Name = "S2"
            };
            Student[] students = new Student[] { s1,s2};
            return View(students);
        }

        public object GetCourse()
        {
            return course;
        }

        public ActionResult Description() {
            Course c = new Course();
            c.Name = "Adv .Net ";
            c.RoomNo = "92023";
            c.Credit = 3;
            return View(c);
        }
    }
}