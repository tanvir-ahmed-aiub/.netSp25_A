using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntroMVC.Models;

namespace IntroMVC.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Bio() { 
            return View();
        }
        public ActionResult Education() {
            Degree d1 = new Degree() { 
                Title = "SSC",
                Ins = "INS1",
                Year = "2018",
                Result = "5.0"
            };
            Degree d2 = new Degree()
            {
                Title = "HSC",
                Ins = "INS2",
                Year = "2020",
                Result = "5.0"
            };
            Degree d3 = new Degree() {
                Title = "BSc",
                Ins = "AIUB",
                Year = "2024",
                Result = "3.0"
            };

            Degree[] degrees = new Degree[] { d1,d2,d3};
            ViewBag.Degrees = degrees;
            return View();
        }
        public ActionResult Qualifiactions() {
            bool hasQualifiactions = false;
            //
            //
            //
            //
            if (hasQualifiactions)
            {
                return View();
            }
            else {
                TempData["Msg"] = "User has no extra qualifications, visit this page instead";
                return RedirectToAction("Education","Portfolio");
            }
            
        }
    }
}