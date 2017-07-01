using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Filters;

namespace MvcApplication2.Controllers
{
    public class WorkerMainController : Controller
    {
        //
        // GET: /WorkerMain/

        public ActionResult Index()
        {
            return View();
        }



        [CustomAuthorization_Worker(LoginPage = "~/WorkerLogin/Create")]
        public ActionResult my()
        {
            return View();
        }


    }
}
