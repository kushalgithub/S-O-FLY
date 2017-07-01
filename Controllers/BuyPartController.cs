using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class BuyPartController : Controller
    {
        //
        // GET: /BuyPart/

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
        public ActionResult Create(Model_BuyPart buy)
        {
            Tbl_BuyPart tbbuy = new Tbl_BuyPart();
            tbbuy.Buy_Id = buy.Buy_Id;
            tbbuy.Part_Id = buy.Part_Id;
            tbbuy.Category_Id = buy.Category_Id;
            tbbuy.SubCategory_Id = buy.SubCategory_Id;
            tbbuy.Quantity = buy.Quantity;
            tbbuy.User_Id = buy.User_Id;
           

            db.Tbl_BuyParts.InsertOnSubmit(tbbuy);
            db.SubmitChanges();
            return View();
        }
    }
}
