using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View(db.Tbl_Categories.ToList());
        }

        public ActionResult WorIndex()
        {
            return View(db.Tbl_Categories.ToList());
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_Category cat)
        {
            Tbl_Category tbcat = new Tbl_Category();
            tbcat.Category_name = cat.Category_name;
            tbcat.Discription = cat.Discription;
            db.Tbl_Categories.InsertOnSubmit(tbcat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Model_Category mdcat = db.Tbl_Categories.Where(x => x.Category_Id == id).Select(x => new Model_Category()
            {
                Category_Id = x.Category_Id,
                Category_name = x.Category_name,
                Discription = x.Discription
            }).SingleOrDefault();
            return View(mdcat);
        }

        [HttpPost]
        public ActionResult Edit(Model_Category cat)
        {
            Tbl_Category tbcat = db.Tbl_Categories.Where(x => x.Category_Id == cat.Category_Id).Single<Tbl_Category>() ;
            tbcat.Category_Id = cat.Category_Id;
            tbcat.Category_name = cat.Category_name;
            tbcat.Discription = cat.Discription;
            
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32 id)
        {
            Model_Category mdcat = db.Tbl_Categories.Where(x => x.Category_Id == id).Select(x => new Model_Category()
            {
                Category_Id = x.Category_Id,
                Category_name = x.Category_name,
                Discription = x.Discription
            }).SingleOrDefault();
            return View(mdcat);
        
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_Category tbcat = db.Tbl_Categories.Where(x => x.Category_Id == id).Single<Tbl_Category>();
            db.Tbl_Categories.DeleteOnSubmit(tbcat);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Model_Category mdcat = db.Tbl_Categories.Where(x => x.Category_Id == id).Select(x => new Model_Category()
            {
                Category_Id = x.Category_Id,
                Category_name = x.Category_name,
                Discription = x.Discription
            }).SingleOrDefault();
            return View(mdcat);
        }

    }
}
