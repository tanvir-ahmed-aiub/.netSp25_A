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
            if (Session["Id"] == null)
            {
                TempData["Msg"] = "Please give Student Id before registration";
                return RedirectToAction("Index","Home");
            }
            //discard already completed courses
            var courses = db.Courses.ToList();
            var sId = Int32.Parse(Session["Id"].ToString());

            var courseStudent = (from cs in db.CourseStudents
                                 where cs.SId == sId
                                 select cs).ToList();
            ViewBag.CourseStudents = courseStudent;

            //var student = db.Students.Find(sId);
            //var studentCourses =student.CourseStudents;
            return View(courses);
        }
        [HttpPost]
        public ActionResult Index(int[] Courses) {
            var sid = Int32.Parse(Session["Id"].ToString());


            var registration = (from r in db.Registrations
                                where r.SId == sid && "Sp24-25".Equals(r.Semester)
                                select r).SingleOrDefault();
            if (registration == null)
            {
                registration = new Registration()
                {
                    EnrollDate = DateTime.Now,
                    SId = sid,
                    Semester = "Sp24-25",
                    Status="Enrolled"

                };
                db.Registrations.Add(registration);
                db.SaveChanges();
            }
            foreach (var item in Courses)
            {
                if (!IsExist(item,sid,registration.Id)) {

                    var course = db.Courses.Find(item);
                    if (course.CourseStudents.Count < course.MaxCapacity)
                    {
                        var cs = new CourseStudent()
                        {
                            CourseId = item,
                            SId = sid,
                            RegId = registration.Id,
                            Date = DateTime.Now,
                            Status = "invalid"
                        };
                        db.CourseStudents.Add(cs);
                    }
                    else {
                        TempData["Msg"] += course.Name+" could not be added";
                    }
                    
                }
                

            }
            db.SaveChanges();



            return RedirectToAction("Index","Home");
        }
        private bool IsExist(int cId, int sId, int regId) {
            var data = (from cs in db.CourseStudents
                        where cs.RegId == regId && cs.CourseId == cId
                        && cs.SId == sId
                        select cs).SingleOrDefault();
            if (data != null) return true;
            return false;
        }
    }
}