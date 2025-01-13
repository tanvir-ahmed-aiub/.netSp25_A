using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierPMS.Controllers
{
    public class ProductController : ApiController
    {

        [HttpGet]
        [Route("api/product/all")]
        public HttpResponseMessage Get()
        {
            var data = ProductService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ProductService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/{id}/category")]
        public HttpResponseMessage Getwith(int id)
        {
            var data = ProductService.GetwithCate(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/search/{name}")]
        public HttpResponseMessage Search(string name)
        {
            var data = ProductService.SearchByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
