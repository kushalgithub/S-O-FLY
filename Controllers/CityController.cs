using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Cities.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_City_tbl city)
        {
            Tbl_City tbcity = new Tbl_City();
            tbcity.City_Name = city.City_Name;
            tbcity.State_Id = city.State_Id;
            db.Tbl_Cities.InsertOnSubmit(tbcity);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            Model_City_tbl mdcity = db.Tbl_Cities.Where(x => x.City_Id == id).Select(x => new Model_City_tbl()
            {
                City_Id = x.City_Id,
                City_Name = x.City_Name,
                State_Id = Convert.ToInt32(x.State_Id),
            }).SingleOrDefault();
            return View(mdcity);
        }

        [HttpPost]
        public ActionResult Edit(Model_City_tbl city)
        {
            Tbl_City tbcity = db.Tbl_Cities.Where(x => x.City_Id == city.City_Id).Single<Tbl_City>();
            tbcity.City_Name = city.City_Name;
            tbcity.State_Id = city.State_Id;
            
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32 id)
        {
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            Model_City_tbl mdcity = db.Tbl_Cities.Where(x => x.City_Id == id).Select(x => new Model_City_tbl()
            {
                City_Id = x.City_Id,
                City_Name = x.City_Name,
                State_Id = Convert.ToInt32(x.State_Id),
            }).SingleOrDefault();
            return View(mdcity);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_City tbcity = db.Tbl_Cities.Where(x => x.City_Id == id).Single<Tbl_City>();
            db.Tbl_Cities.DeleteOnSubmit(tbcity);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            Model_City_tbl mdcity = db.Tbl_Cities.Where(x => x.City_Id == id).Select(x => new Model_City_tbl()
            {
                City_Id = x.City_Id,
                City_Name = x.City_Name,
                State_Id = Convert.ToInt32(x.State_Id),
            }).SingleOrDefault();
            return View(mdcity);
        }

    }
}
