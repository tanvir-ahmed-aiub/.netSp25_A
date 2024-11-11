using EFwithDTO.DTOs;
using EFwithDTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDTO.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        StudentDB_F24_AEntities db = new StudentDB_F24_AEntities();

        public static Department Convert(DepartmentDTO d) {
            return new Department { 
                Id = d.Id,
                Name = d.Name
            };
        }
        public static DepartmentDTO Convert(Department d)
        {
            return new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name
            };
        }
        public static List<DepartmentDTO> Convert(List<Department> data) { 
            var list = new List<DepartmentDTO>();
            foreach (var d in data) { 
                list.Add(Convert(d));
            }
            return list;
        }
        public ActionResult List()
        {
            var data = db.Departments.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create() {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(DepartmentDTO d) {
            //
            if (ModelState.IsValid) {
               
                db.Departments.Add(Convert(d));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
            
        }
        public ActionResult Details(int id) { 
            var exobj = db.Departments.Find(id);
            return View(Convert(exobj));
        }
        [HttpGet]
        public ActionResult Edit(int id) { 
            var exobj = db.Departments.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Edit(DepartmentDTO d) {
            var exobj = db.Departments.Find(d.Id);
            db.Entry(exobj).CurrentValues.SetValues(d);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id) {
            var exobj = db.Departments.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Delete(int Id, string dcsn) {
            if (dcsn.Equals("Yes")) {
                var exobj = db.Departments.Find(Id);
                db.Departments.Remove(exobj);
                db.SaveChanges();
                
            }
            return RedirectToAction("List");
        }

    }
}