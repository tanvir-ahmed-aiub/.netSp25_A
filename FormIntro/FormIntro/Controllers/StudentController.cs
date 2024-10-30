
using FormIntro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormIntro.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet] //annotations
        public ActionResult Create() {
            //ViewBag.Name = Request["Name"];
            //ViewBag.Id = Request["Id"];
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            if (ModelState.IsValid) {
                return RedirectToAction("Index","Home");
            }
            return View(s);
        }
        /*[HttpPost]
        public ActionResult Create(string Name, int Id) { 
            return View();
        }*/
        /*[HttpPost]
        public ActionResult Create(FormCollection fc) {
            ViewBag.Name = fc["Name"];
            ViewBag.Id = fc["Id"];
            return View();
        }*/
    }
}