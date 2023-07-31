using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.AuthenticationClasses
{
    public class EmployeeAuthentication: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if ((int)(httpContext.Session["Auth"]) == 1 || (int)(httpContext.Session["Auth"]) == 2)
            {
                return true;
            }

            httpContext.Response.Redirect("/Management/Manager/Index");
            return false;
        }
    }
}