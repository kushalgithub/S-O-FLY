using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using MvcApplication2.Filters;

namespace MvcApplication2.Controllers
{
    public class ClickServicesController : Controller
    {
        //
        // GET: /ClickServices/
        DataClasses1DataContext db = new DataClasses1DataContext();


        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Services()
        {

            return View(db.Tbl_Services.ToList());
        }



    }
}
