using APIAppi.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppi.Controllers
{
    [RoutePrefix("api/category")]
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {

        [Logged]
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get() {
            var data = CategoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(CategoryDTO c) {
            CategoryService.Create(c);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
