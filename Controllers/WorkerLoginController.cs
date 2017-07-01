using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;


namespace MvcApplication2.Controllers
{
    public class WorkerLoginController : Controller
    {
        //
        // GET: /WorkerLogin/
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
        public ActionResult Create(Model_WorLogin lg)
        {
            Model_Worker ur = db.Tbl_WorkerRegs.Where(x => x.UserName == lg.UserName).Where(x => x.Password == lg.Password).Select(x => new Model_Worker()
            {
                Worker_Id = x.Worker_Id
            }).SingleOrDefault();

            if (ur != null)
            {
                Session["WorkerLoginId"] = ur.Worker_Id;
                return RedirectToAction("my", "WorkerMain");
            }


            else
            {

                return View();
            }
        }


    }
}
