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
        /*public ActionResult Details(string id) { 
            (from s in db.Students
            where s.Name.Contains(id)
            select s).FirstOrDefault();
        }*/
        public ActionResult Details(int id) {
            var data = db.Students.Find(id);
            if (data != null) {
                return View(data);
            }
            TempData["Msg"] = "Student with Id "+id+" not found";
            return RedirectToAction("List");   
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var data = db.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student formObj) {
            //
            //
            
            var exobj = db.Students.Find(formObj.Id);
            formObj.Cgpa = exobj.Cgpa;
            db.Entry(exobj).CurrentValues.SetValues(formObj);
            //Recommended One
            //exobj.Name = formObj.Name;
            //exobj.Cgpa = formObj.Cgpa;


            db.SaveChanges();
            TempData["Msg"] = "Student Updated";
            return RedirectToAction("List");
        }

        //to remove 
        // db.Students.Remove(exobj)
        
    }
}