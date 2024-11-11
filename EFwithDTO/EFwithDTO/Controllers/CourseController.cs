using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDTO.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult List()
        {
            return View();
        }
        
    }
}