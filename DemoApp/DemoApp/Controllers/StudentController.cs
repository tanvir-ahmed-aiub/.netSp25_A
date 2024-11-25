using DemoApp.Auth;
using DemoApp.DTOs;
using DemoApp.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class StudentController : Controller
    {
        Demo_F24_AEntities db = new Demo_F24_AEntities();
        public Student Convert(StudentDTO s) {
            return new Student()
            {
                Name = s.FName + " "+s.LName,
                Semester = s.Semester,
                Email = s.Email,
                Year = DateTime.Now.Year,
                SId = "XX-XXXXX-X"
                //SId = DateTime.Now.Year-2000+"-"+"10000"+"-"+s.Semester
            };
        }
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentDTO());
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s) {
            if (ModelState.IsValid) {
                var efObj = Convert(s);
                db.Students.Add(efObj);
                db.SaveChanges();
                efObj.SId = DateTime.Now.Year - 2000 + "-" + efObj.Id + "-" + efObj.Semester;
                db.SaveChanges();


                return RedirectToAction("Index","Home");
            }

            return View(s);   
        }
        public ActionResult List() {
            var data = db.Students.ToList();
            return View(data);
        }
        [AdminAccess]
        public ActionResult Delete(int id) {
            var st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("List","Student");
        }


    }
}