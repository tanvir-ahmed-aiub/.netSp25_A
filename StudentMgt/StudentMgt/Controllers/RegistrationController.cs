using StudentMgt.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMgt.Controllers
{
    public class RegistrationController : Controller
    {
        StudentMgt_AF25Entities db = new StudentMgt_AF25Entities();
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            //discard already completed courses
            var courses = db.Courses.ToList();
            return View(courses);
        }
        [HttpPost]
        public ActionResult Index(int[] Courses) {
            var id = Int32.Parse(Session["Id"].ToString());


            var registration = (from r in db.Registrations
                                where r.SId == id && "Sp24-25".Equals(r.Semester)
                                select r).SingleOrDefault();
            if (registration == null)
            {
                registration = new Registration()
                {
                    EnrollDate = DateTime.Now,
                    SId = Int32.Parse(Session["Id"].ToString()),
                    Semester = "Sp24-25",
                    Status="Enrolled"

                };
                db.Registrations.Add(registration);
                db.SaveChanges();
            }
            foreach (var item in Courses)
            {
                var cs = new CourseStudent() { 
                    CourseId = item,
                    SId = Int32.Parse(Session["Id"].ToString()),
                    RegId = registration.Id,
                    Date = DateTime.Now,
                    Status ="invalid"
                };
                db.CourseStudents.Add(cs);

            }
            db.SaveChanges();



            return RedirectToAction("Index","Home");
        }
    }
}