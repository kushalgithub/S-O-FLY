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
    public class ClickBuyController : Controller
    {
        //
        // GET: /ClickBuy/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            Model_Parts_tbl mdparts = db.Tbl_Parts.Where(x => x.Part_Id == id).Select(x => new Model_Parts_tbl()
            {
                Part_Id = x.Part_Id,
                PartName = x.PartName,
                Category_Id = Convert.ToInt32(x.Category_Id),
                SubCategory_Id = Convert.ToInt32(x.SubCategory_Id),
                Part_No = x.Part_No,
                PartUsage = x.PartUsage,
                PartPrice = x.PartPrice,
                PartImage = x.PartImage,
            }).SingleOrDefault();
            return View(mdparts);
        }

        [HttpPost]
       
        public ActionResult Create(Model_Parts_tbl buypart)
        {
            string id = Session["UserLoginId"].ToString();
            Tbl_BuyPart tbpart = new Tbl_BuyPart();
            tbpart.Part_Id = buypart.Part_Id;
            tbpart.Category_Id = buypart.Category_Id;
            tbpart.SubCategory_Id = buypart.SubCategory_Id;
            tbpart.PartPrice = buypart.PartPrice;
            tbpart.Quantity = buypart.Quantity;
            tbpart.User_Id = Convert.ToInt32(id);
            db.Tbl_BuyParts.InsertOnSubmit(tbpart);
            db.SubmitChanges();
            return RedirectToAction("Create","ClickBuyConfirm" );
        }


       

    }
}
