using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Areas.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            return View();
        }

         [HttpPost]
        public ActionResult Create(Model_Area_tbl area)
        {
            Tbl_Area tbar = new Tbl_Area();
            tbar.Area_Name = area.Area_Name;
            tbar.City_Id = area.City_Id;
            db.Tbl_Areas.InsertOnSubmit(tbar);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Edit(int id)
         {
             ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
             Model_Area_tbl mdarea = db.Tbl_Areas.Where(x => x.Area_Id == id).Select(x => new Model_Area_tbl()
             {
                 Area_Id = x.Area_Id,
                 Area_Name = x.Area_Name,
                 City_Id = Convert.ToInt32(x.City_Id),
             }).SingleOrDefault();
             return View(mdarea);
         }

         [HttpPost]
         public ActionResult Edit(Model_Area_tbl area)
         {
             Tbl_Area tbar = db.Tbl_Areas.Where(x => x.Area_Id == area.Area_Id).Single<Tbl_Area>();
             tbar.Area_Id = area.Area_Id;
             tbar.Area_Name = area.Area_Name;
             tbar.City_Id = area.City_Id;
             
             db.SubmitChanges();
             return RedirectToAction("Index");
         }

         public ActionResult Delete(Int32 id)
         {
             ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
             Model_Area_tbl mdarea = db.Tbl_Areas.Where(x => x.Area_Id == id).Select(x => new Model_Area_tbl()
             {
                 Area_Id = x.Area_Id,
                 Area_Name = x.Area_Name,
                 City_Id = Convert.ToInt32(x.City_Id),
             }).SingleOrDefault();
             return View(mdarea);
         }

         [HttpPost]
         public ActionResult Delete(Int64 id)
         {
             Tbl_Area tbar = db.Tbl_Areas.Where(x => x.Area_Id == id).Single<Tbl_Area>();
             db.Tbl_Areas.DeleteOnSubmit(tbar);
             db.SubmitChanges();
             return RedirectToAction("Index");

         }

         public ActionResult Details(int id)
         {
             ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
             Model_Area_tbl mdarea = db.Tbl_Areas.Where(x => x.Area_Id == id).Select(x => new Model_Area_tbl()
             {
                 Area_Id = x.Area_Id,
                 Area_Name = x.Area_Name,
                 City_Id = Convert.ToInt32(x.City_Id),
             }).SingleOrDefault();
             return View(mdarea);
         }


    }
}
