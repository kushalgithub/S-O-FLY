using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using System.IO;

namespace MvcApplication2.Controllers
{
    public class ClickBuyServiceController : Controller
    {
        //
        // GET: /ClickBuyService/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create(int id)
        {
            Model_Service mdser = db.Tbl_Services.Where(x => x.Service_Id == id).Select(x => new Model_Service()
            {
                Service_Id = x.Service_Id,
                ServiceName = x.ServiceName,
                ServiceImage = x.ServiceImage,
                ServiceDescription = x.ServiceDiscription,
                ServiceCharge = Convert.ToInt32(x.ServiceCharge),
                }).SingleOrDefault();
            return View(mdser);
        }

        [HttpPost]

        public ActionResult Create(Model_Service buyservice)
        {
            string id = Session["UserLoginId"].ToString();
            Tbl_BuyService tbser = new Tbl_BuyService();
            tbser.Service_Id = buyservice.Service_Id;
            tbser.ServiceCharge = buyservice.ServiceCharge;
           
            tbser.User_Id = Convert.ToInt32(id);
            db.Tbl_BuyServices.InsertOnSubmit(tbser);
            db.SubmitChanges();
            return RedirectToAction("Create", "ClickBuyServiceConfirm");
        }



    }
}
