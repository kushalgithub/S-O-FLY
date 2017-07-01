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
    public class ServiceController : Controller
    {
        //
        // GET: /Service/

        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Services.ToList());
        }


        public ActionResult WorIndex()
        {
            return View(db.Tbl_Services.ToList());
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_Service service)
        {

            HttpPostedFileBase file = Request.Files["file1"];
           
            var filename = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/FileUpload"), filename);
            file.SaveAs(path);
           
            Tbl_Service tbser = new Tbl_Service();
            tbser.Service_Id = service.Service_Id;
            tbser.ServiceName = service.ServiceName;
            tbser.ServiceDiscription = service.ServiceDescription;
            tbser.ServiceCharge = service.ServiceCharge;
            tbser.ServiceImage = file.FileName;
            db.Tbl_Services.InsertOnSubmit(tbser);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {
            Model_Service mdser = db.Tbl_Services.Where(x => x.Service_Id == id).Select(x => new Model_Service()
            {
                Service_Id = x.Service_Id,
                ServiceName = x.ServiceName,
                ServiceDescription = x.ServiceDiscription,
                ServiceCharge = Convert.ToInt32(x.ServiceCharge),
                ServiceImage = x.ServiceImage,
                
            }).SingleOrDefault();
            return View(mdser);
        }

        [HttpPost]
        public ActionResult Edit(Model_Service service)
        {
            Tbl_Service tbser = db.Tbl_Services.Where(x => x.Service_Id == service.Service_Id).Single<Tbl_Service>();

            HttpPostedFileBase file = Request.Files["file1"];
            if (file.FileName == null || file.FileName == "")
            {

            }

            else if (file != null)
            {


                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/FileUpload"), filename);
                file.SaveAs(path);
                tbser.ServiceImage = file.FileName;

            }

            tbser.Service_Id = service.Service_Id;
            tbser.ServiceName = service.ServiceName;
            tbser.ServiceDiscription = service.ServiceDescription;
            tbser.ServiceCharge = service.ServiceCharge;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(Int32 id)
        {
            Model_Service mdser = db.Tbl_Services.Where(x => x.Service_Id == id).Select(x => new Model_Service()
            {
                Service_Id = x.Service_Id,
                ServiceName = x.ServiceName,
                ServiceDescription = x.ServiceDiscription,
                ServiceCharge = Convert.ToInt32(x.ServiceCharge),
                ServiceImage = x.ServiceImage,

            }).SingleOrDefault();
            return View(mdser);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_Service tbser = db.Tbl_Services.Where(x => x.Service_Id == id).Single<Tbl_Service>();
            db.Tbl_Services.DeleteOnSubmit(tbser);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Model_Service mdser = db.Tbl_Services.Where(x => x.Service_Id == id).Select(x => new Model_Service()
            {
                Service_Id = x.Service_Id,
                ServiceName = x.ServiceName,
                ServiceDescription = x.ServiceDiscription,
                ServiceCharge = Convert.ToInt32(x.ServiceCharge),
                ServiceImage = x.ServiceImage,

            }).SingleOrDefault();
            return View(mdser);
        }





    }
}
