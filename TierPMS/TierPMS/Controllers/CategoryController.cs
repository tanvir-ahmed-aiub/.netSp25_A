using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierPMS.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage Get() {
            var data = CategoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data); 
        }
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = CategoryService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/category/{id}/products")]
        public HttpResponseMessage GetwithProducts(int id)
        {
            var data = CategoryService.GetwithProducts(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

