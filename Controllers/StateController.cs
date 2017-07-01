using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class StateController : Controller
    {
        //
        // GET: /State/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_States.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
            return View();
        }

         [HttpPost]
        public ActionResult Create(Model_State_tbl state)
        {
            Tbl_State tbstate = new Tbl_State();
            tbstate.State_Name = state.State_Name;
            tbstate.Country_Id = state.Country_Id;
            db.Tbl_States.InsertOnSubmit(tbstate);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Edit(int id)
         {
             ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
             Model_State_tbl mdstate = db.Tbl_States.Where(x => x.State_Id == id).Select(x => new Model_State_tbl()
             {
                 State_Id = x.State_Id,
                 State_Name = x.State_Name,
                 Country_Id = Convert.ToInt32(x.Country_Id),
             }).SingleOrDefault();
             return View(mdstate);
         }

         [HttpPost]
         public ActionResult Edit(Model_State_tbl state)
         {
             Tbl_State tbstate = db.Tbl_States.Where(x => x.State_Id == state.State_Id).Single<Tbl_State>();
             tbstate.State_Name = state.State_Name;
             tbstate.Country_Id = state.Country_Id;
             
             db.SubmitChanges();
             return RedirectToAction("Index");
         }

         public ActionResult Delete(Int32 id)
         {
             ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
             Model_State_tbl mdstate = db.Tbl_States.Where(x => x.State_Id == id).Select(x => new Model_State_tbl()
             {
                 State_Id = x.State_Id,
                 State_Name = x.State_Name,
                 Country_Id = Convert.ToInt32(x.Country_Id),
             }).SingleOrDefault();
             return View(mdstate);
         }

         [HttpPost]
         public ActionResult Delete(Int64 id)
         {
             Tbl_State tbstate = db.Tbl_States.Where(x => x.State_Id == id).Single<Tbl_State>();
             db.Tbl_States.DeleteOnSubmit(tbstate);
             db.SubmitChanges();
             return RedirectToAction("Index");

         }

         public ActionResult Details(int id)
         {
             ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
             Model_State_tbl mdstate = db.Tbl_States.Where(x => x.State_Id == id).Select(x => new Model_State_tbl()
             {
                 State_Id = x.State_Id,
                 State_Name = x.State_Name,
                 Country_Id = Convert.ToInt32(x.Country_Id),
             }).SingleOrDefault();
             return View(mdstate);
         }


    }
}
