using IntroAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class CategoryController : ApiController
    {
        PMS_Sp25_AEntities db = new PMS_Sp25_AEntities();
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage AllCats() {
            var data = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
        [HttpGet]
        [Route("api/category/{id}/name/{name}")]
        public HttpResponseMessage Category(int id, string name) {
            var data = db.Categories.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Create(Category c) {
            c.CreatedBy = 99;
            c.CreatedAt = DateTime.Now;
            db.Categories.Add(c);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created,"Category Created");
        }
    }
}
