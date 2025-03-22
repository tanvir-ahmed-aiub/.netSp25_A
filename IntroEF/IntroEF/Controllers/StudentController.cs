using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        Sp25_A_Demo1Entities1 db = new Sp25_A_Demo1Entities1();
        // GET: Student
        public ActionResult Index()
        {
            //All students view
            
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
          
            //validation
           
            db.Students.Add(s);
            // returns no of rows effected
            if (db.SaveChanges() > 0) {
                TempData["Msg"] = "User Added";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "User Not Added";
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var data = db.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student s) {
            var exobj = db.Students.Find(s.Id);
            //db.Entry(exobj).CurrentValues.SetValues(s);
            exobj.Name = s.Name;
            exobj.Dob = s.Dob;
            db.SaveChanges();
            TempData["Msg"] = "Student Updated";
            return RedirectToAction("Index");

            //db.Students.Remove(s);
            //db.SaveChanges();
            //Take consent from user to delete
            //then delete

               

        }
    }
}