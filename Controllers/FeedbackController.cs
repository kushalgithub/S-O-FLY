using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using MvcApplication2.Filters;

namespace MvcApplication2.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/

        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Feedbacks.ToList());

        }

        public ActionResult WorIndex()
        {
            return View(db.Tbl_Feedbacks.ToList());

        }


        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_Feedback feed)
        {
            string id = Session["UserLoginId"].ToString();
            Tbl_Feedback tbfeed = new Tbl_Feedback();
            tbfeed.Feedback_Id = feed.Feedback_Id;
            tbfeed.User_Id = Convert.ToInt32(id);
            tbfeed.Feedback = feed.Feedback;
            tbfeed.Rating = feed.Rating;
            db.Tbl_Feedbacks.InsertOnSubmit(tbfeed);
            db.SubmitChanges();
            return RedirectToAction("my", "User");
        }

        public ActionResult Delete(Int32 id)
        {
                  Model_Feedback mdfeed = db.Tbl_Feedbacks.Where(x => x.Feedback_Id == id).Select(x => new Model_Feedback()
            {
                Feedback_Id = x.Feedback_Id,
                Feedback = x.Feedback,
                User_Id = Convert.ToInt32(x.User_Id),
                Rating = Convert.ToInt32(x.Rating),
                UserName = x.Tbl_UserReg.UserName,
            }).SingleOrDefault();
            return View(mdfeed);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_Feedback tbfeed = db.Tbl_Feedbacks.Where(x => x.Feedback_Id == id).Single<Tbl_Feedback>();
            db.Tbl_Feedbacks.DeleteOnSubmit(tbfeed);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(Int32 id)
        {
            Model_Feedback mdfeed = db.Tbl_Feedbacks.Where(x => x.Feedback_Id == id).Select(x => new Model_Feedback()
            {
                Feedback_Id = x.Feedback_Id,
                Feedback = x.Feedback,
                User_Id = Convert.ToInt32(x.User_Id),
                Rating = Convert.ToInt32(x.Rating),
                UserName = x.Tbl_UserReg.UserName,
            }).SingleOrDefault();
            return View(mdfeed);
        }


    }
}
