using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class CarController : Controller
    {
        //
        // GET: /Car/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_Car car)
        {
            Tbl_Car tbcar = new Tbl_Car();
            tbcar.Car_Id = car.Car_Id;
            tbcar.Car_Model = car.Car_Model;
            tbcar.Car_No = car.Car_No;
            tbcar.User_Id = car.User_Id;
            db.Tbl_Cars.InsertOnSubmit(tbcar);
            db.SubmitChanges();
            return RedirectToAction("my", "User");
        }
    }
}
