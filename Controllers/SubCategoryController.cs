using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;


namespace MvcApplication2.Controllers
{
    public class SubCategoryController : Controller
    {
        //
        // GET: /SubCategory/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_SubCategoties.ToList());
        }

        public ActionResult WorIndex()
        {
            return View(db.Tbl_SubCategoties.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_SubCategory_tbl subcat)
        {

            Tbl_SubCategoty tbsubcat = new Tbl_SubCategoty();
            tbsubcat.SubCateName = subcat.SubCateName;
            tbsubcat.SubCateDiscription = subcat.SubCateDiscription;
            tbsubcat.Category_Id = subcat.Category_Id;
            db.Tbl_SubCategoties.InsertOnSubmit(tbsubcat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
            Model_SubCategory_tbl mdsubcat = db.Tbl_SubCategoties.Where(x => x.SubCategory_Id == id).Select(x => new Model_SubCategory_tbl()
            {
               SubCategory_Id = x.SubCategory_Id,
               SubCateName = x.SubCateName,
               SubCateDiscription = x.SubCateDiscription,
               Category_Id =Convert.ToInt32(x.Category_Id),
            }).SingleOrDefault();
            return View(mdsubcat);
        }

        [HttpPost]
        public ActionResult Edit(Model_SubCategory_tbl subcat)
        {
            Tbl_SubCategoty tbsubcat = db.Tbl_SubCategoties.Where(x => x.SubCategory_Id == subcat.SubCategory_Id).Single<Tbl_SubCategoty>();
            tbsubcat.SubCateName = subcat.SubCateName;
            tbsubcat.SubCateDiscription = subcat.SubCateDiscription;
            tbsubcat.Category_Id = subcat.Category_Id;
            
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32 id)
        {
            ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
            Model_SubCategory_tbl mdsubcat = db.Tbl_SubCategoties.Where(x => x.SubCategory_Id == id).Select(x => new Model_SubCategory_tbl()
            {
                SubCategory_Id = x.SubCategory_Id,
                SubCateName = x.SubCateName,
                SubCateDiscription = x.SubCateDiscription,
                Category_Id = Convert.ToInt32(x.Category_Id),
            }).SingleOrDefault();
            return View(mdsubcat);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_SubCategoty tbsub = db.Tbl_SubCategoties.Where(x => x.SubCategory_Id == id).Single<Tbl_SubCategoty>();
            db.Tbl_SubCategoties.DeleteOnSubmit(tbsub);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            ViewBag.catid = new SelectList(db.Tbl_Categories, "Category_Id", "Category_name");
            Model_SubCategory_tbl mdsubcat = db.Tbl_SubCategoties.Where(x => x.SubCategory_Id == id).Select(x => new Model_SubCategory_tbl()
            {
                SubCategory_Id = x.SubCategory_Id,
                SubCateName = x.SubCateName,
                SubCateDiscription = x.SubCateDiscription,
                Category_Id = Convert.ToInt32(x.Category_Id),
            }).SingleOrDefault();
            return View(mdsubcat);
        }

    }
}
