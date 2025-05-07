using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Auth
{
    public class AdminAuth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (Login)httpContext.Session["User"];
            if (user != null && user.UserType.Equals("Admin")) return true;
            return false;
        }
    }
}