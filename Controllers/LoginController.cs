using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        DataClasses1DataContext db = new DataClasses1DataContext();
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
        public ActionResult Create(Model_Login lg)
        {
            Model_UserReg ur = db.Tbl_UserRegs.Where(x => x.UserName == lg.UserName).Where(x => x.Password == lg.Password).Select(x => new Model_UserReg() { 
            User_Id = x.User_Id
            }).SingleOrDefault();

            if (ur != null)
            {
                Session["UserLoginId"] = ur.User_Id;
                return RedirectToAction("Create", "Welcome");
            }


            else
            {

                return View();
            }
        }


    }
}
