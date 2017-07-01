using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using System.IO;
using MvcApplication2.Filters;


namespace MvcApplication2.Controllers
{
    public class ClickBuyServiceConfirmController : Controller
    {
        //
        // GET: /ClickBuyServiceConfirm/
        DataClasses1DataContext db = new DataClasses1DataContext();


        public ActionResult Index()
        {
            return View(db.Tbl_BuyServices.ToList());
        }

        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Create()
        {

            return View(db.Tbl_BuyServices.Where(x => x.User_Id == Convert.ToInt32(Session["UserLoginId"].ToString())));
        }

        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Track()
        {

            return View(db.Tbl_BuyServices.Where(x => x.User_Id == Convert.ToInt32(Session["UserLoginId"].ToString())));
        }




        public ActionResult Delete(Int32 id)
        {


            Tbl_BuyService tbser = db.Tbl_BuyServices.Where(x => x.BuyService_Id == id).Single<Tbl_BuyService>();
            db.Tbl_BuyServices.DeleteOnSubmit(tbser);
            db.SubmitChanges();
            return RedirectToAction("Create");
        }


        public ActionResult Edit(int id)
        {
            Model_BuyService mdbs = db.Tbl_BuyServices.Where(x => x.BuyService_Id == id).Select(x => new Model_BuyService()
            {
                BuyService_Id = x.BuyService_Id,
                Service_Id =Convert.ToInt32( x.Service_Id),
                User_Id =Convert.ToInt32( x.User_Id),
                ServiceCharge =Convert.ToInt32( x.ServiceCharge),
                Status = x.Status,
                
            }).SingleOrDefault();
            return View(mdbs);
        }

        [HttpPost]
        public ActionResult Edit(Model_BuyService bs)
        {
            Tbl_BuyService tbbs = db.Tbl_BuyServices.Where(x => x.BuyService_Id == bs.BuyService_Id).Single<Tbl_BuyService>();
            tbbs.BuyService_Id = bs.BuyService_Id;
            tbbs.Service_Id = bs.Service_Id;
            tbbs.User_Id = bs.User_Id;
            tbbs.ServiceCharge = bs.ServiceCharge;
            tbbs.Status = bs.Status;
            db.SubmitChanges();

            return RedirectToAction("Index");
        }



    }
}
