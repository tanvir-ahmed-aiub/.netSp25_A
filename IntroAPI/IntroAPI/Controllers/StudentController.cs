using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class StudentController : ApiController
    {
        public HttpResponseMessage Get() {



            return Request.CreateResponse(HttpStatusCode.OK,"Get Called");
        }
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Get Called" +id );
        }

        public HttpResponseMessage Post() {
            return Request.CreateResponse(HttpStatusCode.OK, "Post Called");
        }
        public HttpResponseMessage Delete() {
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Called");
        }
    }
}
