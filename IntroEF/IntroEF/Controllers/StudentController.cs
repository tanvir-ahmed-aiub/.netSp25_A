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
        StudentDB_F24_AEntities db = new StudentDB_F24_AEntities();
        // GET: Student
        public ActionResult List()
        {
            var data = db.Students.ToList();
            
            return View(data);
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            //validation
            db.Students.Add(s);
            db.SaveChanges();
            TempData["Msg"] = "Student Created";
            return RedirectToAction("List");

        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        public ActionResult Details(int id) {
            var data = db.Students.Find(id);
            if (data != null) {
                return View(data);
            }
            TempData["Msg"] = "Student with Id "+id+" not found";
            return RedirectToAction("List");
            
            
        }
        
    }
}