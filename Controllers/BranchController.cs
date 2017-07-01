using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class BranchController : Controller
    {
        //
        // GET: /Branch/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Branches.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.areaid = new SelectList(db.Tbl_Areas, "Area_Id", "Area_Name");
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");

            return View();
        }

         [HttpPost]
        public ActionResult Create(Model_Branch_tbl branch)
        {
            Tbl_Branch tbbr = new Tbl_Branch();
            tbbr.Address = branch.Address;
            tbbr.Area_Id = branch.Area_Id;
            tbbr.City_Id = branch.City_Id;
            tbbr.State_Id = branch.State_Id;
            tbbr.Country_Id = branch.Country_Id;
            tbbr.Contact_No = branch.Contact_No;
            db.Tbl_Branches.InsertOnSubmit(tbbr);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }

         public ActionResult Edit(int id)
         {
             ViewBag.areaid = new SelectList(db.Tbl_Areas, "Area_Id", "Area_Name");
             ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
             ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
             ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
             Model_Branch_tbl mdbr = db.Tbl_Branches.Where(x => x.Branch_Id == id).Select(x => new Model_Branch_tbl()
             {
                 Branch_Id = x.Branch_Id,
                 Address = x.Address,
                 Area_Id = x.Area_Id,
                 City_Id = x.City_Id,
                 State_Id = x.State_Id,
                 Country_Id = x.Country_Id,
                 Contact_No =Convert.ToInt32(x.Contact_No),

             }).SingleOrDefault();
             return View(mdbr);
         }

         [HttpPost]
         public ActionResult Edit(Model_Branch_tbl branch)
         {
             Tbl_Branch tbbr = db.Tbl_Branches.Where(x => x.Branch_Id ==branch.Branch_Id).Single<Tbl_Branch>();
             tbbr.Address = branch.Address;
             tbbr.Area_Id = branch.Area_Id;
             tbbr.City_Id = branch.City_Id;
             tbbr.State_Id = branch.State_Id;
             tbbr.Country_Id = branch.Country_Id;
             tbbr.Contact_No = branch.Contact_No;
            
             db.SubmitChanges();

             return RedirectToAction("Index");
         }

         public ActionResult Delete(Int32 id)
         {
             ViewBag.areaid = new SelectList(db.Tbl_Areas, "Area_Id", "Area_Name");
             ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
             ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
             ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
             Model_Branch_tbl mdbr = db.Tbl_Branches.Where(x => x.Branch_Id == id).Select(x => new Model_Branch_tbl()
             {
                 Branch_Id = x.Branch_Id,
                 Address = x.Address,
                 Area_Id = x.Area_Id,
                 City_Id = x.City_Id,
                 State_Id = x.State_Id,
                 Country_Id = x.Country_Id,
                 Contact_No = Convert.ToInt32(x.Contact_No),

             }).SingleOrDefault();
             return View(mdbr);
         }

         [HttpPost]
         public ActionResult Delete(Int64 id)
         {
             Tbl_Branch tbbr = db.Tbl_Branches.Where(x => x.Branch_Id == id).Single<Tbl_Branch>();
             db.Tbl_Branches.DeleteOnSubmit(tbbr);
             db.SubmitChanges();
             return RedirectToAction("Index");

         }


         public ActionResult Details(int id)
         {
             ViewBag.areaid = new SelectList(db.Tbl_Areas, "Area_Id", "Area_Name");
             ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
             ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
             ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
             Model_Branch_tbl mdbr = db.Tbl_Branches.Where(x => x.Branch_Id == id).Select(x => new Model_Branch_tbl()
             {
                 Branch_Id = x.Branch_Id,
                 Address = x.Address,
                 Area_Id = x.Area_Id,
                 City_Id = x.City_Id,
                 State_Id = x.State_Id,
                 Country_Id = x.Country_Id,
                 Contact_No = Convert.ToInt32(x.Contact_No),

             }).SingleOrDefault();
             return View(mdbr);
         }

         public ActionResult LoadState(int id)
         {
             var data = from st in db.Tbl_States
                        where st.Country_Id == id
                        select st;
             return Json(new SelectList(data, "State_Id", "State_Name"));
         }

         public ActionResult LoadCity(int id)
         {
             var data = from city in db.Tbl_Cities
                        where city.City_Id == id
                        select city;
             return Json(new SelectList(data, "City_Id", "City_Name"));
         }

         public ActionResult LoadArea(int id)
         {
             var data = from area in db.Tbl_Areas
                        where area.Area_Id == id
                        select area;
             return Json(new SelectList(data, "Area_Id", "Area_Name"));
         }




    }
}
