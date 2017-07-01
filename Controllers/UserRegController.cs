using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;

namespace MvcApplication2.Controllers
{
    public class UserRegController : Controller
    {
        //
        // GET: /UserReg/

        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {

            return View(db.Tbl_UserRegs.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_UserReg ur)
        {
            Tbl_UserReg tbur = new Tbl_UserReg();
            tbur.User_Id = ur.User_Id;
            tbur.FirstName = ur.FirstName;
            tbur.LastName = ur.LastName;
            tbur.UserName = ur.UserName;
            tbur.Password = ur.Password;
            tbur.ConfirmPassword = ur.ConfirmPassword;
            tbur.Address = ur.Address;
            tbur.Country_Id = ur.Country_Id;
            tbur.State_Id = ur.State_Id;
            tbur.City_Id = ur.City_Id;
            tbur.Email = ur.Email;
            tbur.ContactNumber = ur.ContactNumber;
            tbur.Login_Id = ur.Login_Id;

            db.Tbl_UserRegs.InsertOnSubmit(tbur);
            db.SubmitChanges();
            return RedirectToAction("Create", "Login");
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

        public ActionResult checkmail(string email)
        {
            var data = from rg in db.Tbl_UserRegs
                       where rg.Email== email
                       select rg;
            if (data.Count() > 0)
            {
                return Json(""); 
            }
            else
            {
                return Json("Email");
            }
         
        }
    }
}
