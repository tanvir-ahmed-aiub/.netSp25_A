using APIAppi.Auth;
using APIAppi.Models;
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
    [EnableCors("*","*","*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Auth(LoginModel login) {
            var tk = AuthService.Auth(login.UName, login.Password);
            if (tk != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, tk);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Uname Pass Invalid");
            }
        }
        [Logged]
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout() {
            var token = Request.Headers.Authorization.ToString();
            var rettk = AuthService.Logout(token);
            return Request.CreateResponse(HttpStatusCode.OK, rettk);
        }
    }
}
