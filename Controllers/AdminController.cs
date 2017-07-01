using MvcApplication2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }


        [CustomAuthorization_Admin(LoginPage = "~/AdminLogin/Create")]
        public ActionResult my()
        {
            return View();
        }

    }
}
