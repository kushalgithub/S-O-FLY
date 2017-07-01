using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Countries.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Model_Country_tbl country)
        {
            Tbl_Country tbcoun = new Tbl_Country();
            tbcoun.Country_Name = country.Country_Name;
            db.Tbl_Countries.InsertOnSubmit(tbcoun);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Model_Country_tbl mdcountry = db.Tbl_Countries.Where(x => x.Country_Id == id).Select(x => new Model_Country_tbl()
            {
                Country_Id = x.Country_Id,
                Country_Name = x.Country_Name,
                
            }).SingleOrDefault();
            return View(mdcountry);
        }

        [HttpPost]
        public ActionResult Edit(Model_Country_tbl country)
        {
            Tbl_Country tbcoun = db.Tbl_Countries.Where(x => x.Country_Id == country.Country_Id).Single<Tbl_Country>();
            tbcoun.Country_Name = country.Country_Name;
            
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32 id)
        {
            Model_Country_tbl mdcountry = db.Tbl_Countries.Where(x => x.Country_Id == id).Select(x => new Model_Country_tbl()
            {
                Country_Id = x.Country_Id,
                Country_Name = x.Country_Name,

            }).SingleOrDefault();
            return View(mdcountry);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_Country tbcoun = db.Tbl_Countries.Where(x => x.Country_Id == id).Single<Tbl_Country>();
            db.Tbl_Countries.DeleteOnSubmit(tbcoun);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Details(int id)
        {
            Model_Country_tbl mdcountry = db.Tbl_Countries.Where(x => x.Country_Id == id).Select(x => new Model_Country_tbl()
            {
                Country_Id = x.Country_Id,
                Country_Name = x.Country_Name,

            }).SingleOrDefault();
            return View(mdcountry);
        }


    }
}
