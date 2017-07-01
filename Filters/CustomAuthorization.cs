using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Filters
{
    public class CustomAuthorization_Admin : AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session["adminId"] == null)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }

           
        }
    }

    public class CustomAuthorization_User : AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session["UserLoginId"] == null)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }

            
        }
    }


    public class CustomAuthorization_Worker : AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session["WorkerLoginId"] == null)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }


        }
    }



    }