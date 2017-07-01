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
    public class ClickBuyConfirmController : Controller
    {
        //
        // GET: /ClickBuyConfirm/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View();
        }



        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Create()
        {

            return View(db.Tbl_BuyParts.Where(x => x.User_Id == Convert.ToInt32(Session["UserLoginId"].ToString())));
        }

        
        
        
        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult MyParts()
        {

            return View(db.Tbl_BuyParts.Where(x => x.User_Id == Convert.ToInt32(Session["UserLoginId"].ToString())));
        }



        public ActionResult Delete(Int32 id)
        {


            Tbl_BuyPart tbpart = db.Tbl_BuyParts.Where(x => x.Buy_Id == id).Single<Tbl_BuyPart>();
            db.Tbl_BuyParts.DeleteOnSubmit(tbpart);
            db.SubmitChanges();
            return RedirectToAction("Create");
        }

       


    }
}
