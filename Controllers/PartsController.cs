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
    public class PartsController : Controller
    {
        //
        // GET: /Parts/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Parts.ToList());
        }

        public ActionResult WorIndex()
        {
            return View(db.Tbl_Parts.ToList());
        }



        public ActionResult Create()
        {
            ViewBag.subcatid = new SelectList(db.Tbl_SubCategoties, "SubCategory_Id", "SubCateName");
            ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
            return View();
        }

     [HttpPost]
        public ActionResult Create(Model_Parts_tbl parts)
        {
        
            HttpPostedFileBase file = Request.Files["file1"];
           
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUpload"), filename);
                    file.SaveAs(path);
          

            Tbl_Part tbpart = new Tbl_Part();
            tbpart.Part_No = parts.Part_No;
            tbpart.PartName = parts.PartName;
            tbpart.Category_Id = parts.Category_Id;
            tbpart.PartUsage = parts.PartUsage;
            tbpart.PartPrice = parts.PartPrice;
            tbpart.SubCategory_Id = parts.SubCategory_Id;
            tbpart.PartImage = file.FileName;
            db.Tbl_Parts.InsertOnSubmit(tbpart);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

     public ActionResult Edit(int id)
     {
         ViewBag.subcatid = new SelectList(db.Tbl_SubCategoties, "SubCategory_Id", "SubCateName");
         ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
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
     public ActionResult Edit(Model_Parts_tbl parts)
     {
         Tbl_Part tbpart = db.Tbl_Parts.Where(x => x.Part_Id == parts.Part_Id).Single<Tbl_Part>();

         HttpPostedFileBase file = Request.Files["file1"];
         if (file.FileName == null || file.FileName == "")
         {

         }

         else if(file != null)
         {

             
         var filename = Path.GetFileName(file.FileName);
         var path = Path.Combine(Server.MapPath("~/FileUpload"), filename);
         file.SaveAs(path);
         tbpart.PartImage = file.FileName;

     }
         
         tbpart.Part_No = parts.Part_No;
         tbpart.PartName = parts.PartName;
         tbpart.Category_Id = parts.Category_Id;
         tbpart.PartUsage = parts.PartUsage;
         tbpart.PartPrice = parts.PartPrice;
         tbpart.SubCategory_Id = parts.SubCategory_Id;
         
         db.SubmitChanges();
         return RedirectToAction("Index");
     }

     public ActionResult Delete(Int32 id)
     {
         ViewBag.subcatid = new SelectList(db.Tbl_SubCategoties, "SubCategory_Id", "SubCateName");
         ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
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
     public ActionResult Delete(Int64 id)
     {
         Tbl_Part tbpart = db.Tbl_Parts.Where(x => x.Part_Id == id).Single<Tbl_Part>();
         db.Tbl_Parts.DeleteOnSubmit(tbpart);
         db.SubmitChanges();
         return RedirectToAction("Index");

     }


     public ActionResult Details(int id)
     {
         ViewBag.subcatid = new SelectList(db.Tbl_SubCategoties, "SubCategory_Id", "SubCateName");
         ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
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

     public ActionResult LoadSubCate(int id)
     {
         var data = from sub in db.Tbl_SubCategoties
                    where sub.SubCategory_Id == id
                    select sub;
         return Json(new SelectList(data, "SubCategory_Id", "SubCateName"));
     }


    }
}
