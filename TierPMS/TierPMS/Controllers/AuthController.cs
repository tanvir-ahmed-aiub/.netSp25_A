using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierPMS.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(UserDTO u) {
            var data = AuthService.Autheiticate(u.Username, u.Password);
            if (data !=null ) {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout(TokenDTO token)
        {
            var data = AuthService.Logout(token.Key);
            if (data ==true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Logout successful");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

    }
}
