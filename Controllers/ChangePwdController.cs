using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using System.IO;
using MvcApplication2.Filters;


namespace MvcApplication2.Controllers
{
    public class ChangePwdController : Controller
    {
        //
        // GET: /ChangePwd/

        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View();
        }


        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Create()
        {
                       return View();
        }


        [HttpPost]
        public ActionResult Create(Model_Login cp)
        {
            int uid =  Convert.ToInt32(Session["UserLoginId"].ToString());
            Model_UserReg reg = db.Tbl_UserRegs.Where(x => x.Password == cp.Password && x.User_Id == uid).Select(x => new Model_UserReg()
            {
                
            }).SingleOrDefault();
            if (reg != null)
            {
                Tbl_UserReg tbur = db.Tbl_UserRegs.Where(x => x.User_Id == uid).Single<Tbl_UserReg>();
                tbur.Password = cp.NewPassword;
                tbur.ConfirmPassword = cp.ConfirmPassword;
                db.SubmitChanges();

            }

            return View();
            
        }




    }
}
