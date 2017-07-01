using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;


namespace MvcApplication2.Controllers
{
    public class AdminLoginController : Controller
    {
        //
        // GET: /AdminLogin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Model_LoginAdmin lg)
        {
            if (lg.UserName == "admin" && lg.Password == "admin")
            {
                Session["adminId"] = "1";
                return RedirectToAction("my", "Admin");
            }

            return View();
        }


    }
}
