using DTO.DTOs;
using DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTO.Controllers
{
    public class StudentController : Controller
    {
        private Sp25_A_Demo1Entities db = new Sp25_A_Demo1Entities();
        // GET: Student
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create() { 

            return View();  
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s) {
            if (ModelState.IsValid) {
                var st = Convert(s);
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(s);
        }

        public static Student Convert(StudentDTO s) {
            return new Student() {
                Name = s.FName + " "+s.LName,
                Cgpa = s.Cgpa,
                Dob = s.Dob,
                Age = DateTime.Now.Year - s.Dob.Year
            };
        }
        public static StudentDTO Convert(Student s)
        {
            var name = s.Name.Split(' ');
            return new StudentDTO()
            {
                FName = name[0],
                LName = name[1],
                Cgpa = s.Cgpa,
                Dob = s.Dob,
         
            };
        }
        public static List<StudentDTO> Convert(List<Student> list) {
            var data = new List<StudentDTO>();
            foreach (var student in list) {
                data.Add(Convert(student));
            }
            return data;
        }
    }
}