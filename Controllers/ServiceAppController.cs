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
    public class ServiceAppController : Controller
    {
        //
        // GET: /ServiceApp/
        DataClasses1DataContext db = new DataClasses1DataContext();

       
        public ActionResult Index()
        {
            return View(db.Tbl_ServiceApps.ToList());
        }
        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Create()
        {
            ViewBag.branchid = new SelectList(db.Tbl_Branches, "Branch_Id", "Address");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_ServiceApp sa)
        {

            string id = Session["UserLoginId"].ToString();
            Tbl_ServiceApp tbsa = new Tbl_ServiceApp();
            tbsa.User_Id = Convert.ToInt32(id);
            tbsa.Service_Id = sa.Service_Id;
            tbsa.Appointment_Date = sa.Appointment_Date;
            tbsa.Branch_Id = sa.Branch_Id;
            tbsa.Problem = sa.Problem;
            tbsa.CarModel = sa.CarModel;
            tbsa.Branch_Id = sa.Branch_Id;
            db.Tbl_ServiceApps.InsertOnSubmit(tbsa);
            db.SubmitChanges();
            return RedirectToAction("my", "User");
        }

    }
}
