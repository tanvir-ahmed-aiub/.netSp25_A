using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index() {
            return View(new Student()) ;
        }
        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid) {
                return RedirectToAction("About","Home");
            }
            return View(s);
        }
        //[HttpPost]
        //public ActionResult Index(string Name, string Id, string Email) {
        //    ViewBag.Name = Name;
        //    ViewBag.Email = Email;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Index(FormCollection fc)
        //{
        //    ViewBag.Name = Request["Name"];
        //    ViewBag.Email = fc["Email"];
        //    return View();
        //}
    }
}