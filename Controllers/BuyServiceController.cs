using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;


namespace MvcApplication2.Controllers
{
    public class BuyServiceController : Controller
    {
        //
        // GET: /BuyService/
        DataClasses1DataContext db = new DataClasses1DataContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_BuyService buy)
        {
            Tbl_BuyService tbbuy = new Tbl_BuyService();
            tbbuy.BuyService_Id = buy.BuyService_Id;
            tbbuy.Service_Id = buy.Service_Id;
            tbbuy.ServiceCharge = buy.ServiceCharge;
            tbbuy.User_Id = buy.User_Id;


            db.Tbl_BuyServices.InsertOnSubmit(tbbuy);
            db.SubmitChanges();
            return View();
        }



    }
}
