using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using System.IO;
using MvcApplication2.Filters;
using System.Net;
using System.Net.Mail;


namespace MvcApplication2.Controllers
{
    public class WorkerController : Controller
    {
        //
        // GET: /Worker/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_WorkerRegs.ToList());
        }

        public ActionResult Create()
        {
           
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
            return View();

        }

        [HttpPost]
        public ActionResult Create(Model_Worker worker)
        {
            Tbl_WorkerReg tbworker = new Tbl_WorkerReg();
            tbworker.FirstName = worker.FirstName;
            tbworker.LastName = worker.LastName;
            tbworker.UserName = worker.UserName;
            tbworker.Password = worker.Password;
            tbworker.Address = worker.Address;
            tbworker.Country_Id = worker.Country_Id;
            tbworker.State_Id = worker.State_Id;
            tbworker.City_Id = worker.City_Id;
            tbworker.Experience = worker.Experience;
            tbworker.Contact_No = worker.Contact_No;
            tbworker.Email = worker.Email;
            tbworker.Branch_Id = worker.Branch_Id;
            tbworker.Login_Id = worker.Login_Id;
            db.Tbl_WorkerRegs.InsertOnSubmit(tbworker);
            db.SubmitChanges();
            SendMail(worker.Email, "", "Registration Detail", "Your User Name : " + worker.UserName + " and Password : " + worker.Password, "");
            return RedirectToAction("Index");
        }

        public static void SendMail(string strTo, string strCC, string strSubject, string strBody, string AttachmentFilePath)
        {
            try
            {
                string from = "carsofly@gmail.com";
                string fromname = "S-O-FLY";
                string smtpServer = "smtp.gmail.com";  //"mail.aromonic.com";
                string pas = "carsofly123";

                MailAddress mailfrom = new MailAddress(from, fromname);
                MailAddress Mailto = new MailAddress(strTo, strTo);
                MailMessage mail = new MailMessage(mailfrom, Mailto);

                // MailMessage mail = new MailMessage();

                var smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = smtpServer;
                smtp.Port = 587;

                mail.Subject = strSubject;
                mail.Body = strBody;
                mail.IsBodyHtml = true;

                if (strCC.Trim() != "")
                    mail.CC.Add(strCC);

                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pas);
                //smtp.Timeout = 20000;

                smtp.Send(mail);
            }
            catch (Exception Exc)
            {
                //  lblmsg.Text =Exc.Message;
            }
        }


        public ActionResult Edit(int id)
        {
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
            Model_Worker mdworker = db.Tbl_WorkerRegs.Where(x => x.Worker_Id == id).Select(x => new Model_Worker()
            {
                Worker_Id = x.Worker_Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Password = x.Password,
                Address = x.Address,
               Country_Id = Convert.ToInt32(x.Country_Id),
                State_Id = Convert.ToInt32(x.State_Id),
                City_Id = Convert.ToInt32(x.City_Id),
               Experience = x.Experience,
                Contact_No =Convert.ToInt32(x.Contact_No),
                Email = x.Email,
                Branch_Id = Convert.ToInt32(x.Branch_Id),
                Login_Id = Convert.ToInt32(x.Login_Id),
            }).SingleOrDefault();
            return View(mdworker);
        }

        [HttpPost]
        public ActionResult Edit(Model_Worker worker)
        {
            Tbl_WorkerReg tbworker = db.Tbl_WorkerRegs.Where(x => x.Worker_Id == worker.Worker_Id).Single<Tbl_WorkerReg>();
            tbworker.FirstName = worker.FirstName;
            tbworker.LastName = worker.LastName;
            tbworker.UserName = worker.UserName;
            tbworker.Password = worker.Password;
            tbworker.Address = worker.Address;
            tbworker.Country_Id = worker.Country_Id;
            tbworker.State_Id = worker.State_Id;
            tbworker.City_Id = worker.City_Id;
            tbworker.Experience = worker.Experience;
            tbworker.Contact_No = worker.Contact_No;
            tbworker.Email = worker.Email;
            tbworker.Branch_Id = worker.Branch_Id;
            tbworker.Login_Id = worker.Login_Id;
           
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32 id)
        {
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
            Model_Worker mdworker = db.Tbl_WorkerRegs.Where(x => x.Worker_Id == id).Select(x => new Model_Worker()
            {
                Worker_Id = x.Worker_Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Password = x.Password,
                Address = x.Address,
                Country_Id = Convert.ToInt32(x.Country_Id),
                State_Id = Convert.ToInt32(x.State_Id),
                City_Id = Convert.ToInt32(x.City_Id),
                Experience = x.Experience,
                Contact_No = Convert.ToInt32(x.Contact_No),
                Email = x.Email,
                Branch_Id = Convert.ToInt32(x.Branch_Id),
                Login_Id = Convert.ToInt32(x.Login_Id),
            }).SingleOrDefault();
            return View(mdworker);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_WorkerReg tbworker = db.Tbl_WorkerRegs.Where(x => x.Worker_Id == id).Single<Tbl_WorkerReg>();
            db.Tbl_WorkerRegs.DeleteOnSubmit(tbworker);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Details(int id)
        {
            ViewBag.cityid = new SelectList(db.Tbl_Cities, "City_Id", "City_Name");
            ViewBag.stateid = new SelectList(db.Tbl_States, "State_Id", "State_Name");
            ViewBag.countryid = new SelectList(db.Tbl_Countries, "Country_Id", "Country_Name");
            Model_Worker mdworker = db.Tbl_WorkerRegs.Where(x => x.Worker_Id == id).Select(x => new Model_Worker()
            {
                Worker_Id = x.Worker_Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Password = x.Password,
                Address = x.Address,
                Country_Id = Convert.ToInt32(x.Country_Id),
                State_Id = Convert.ToInt32(x.State_Id),
                City_Id = Convert.ToInt32(x.City_Id),
                Experience = x.Experience,
                Contact_No = Convert.ToInt32(x.Contact_No),
                Email = x.Email,
                Branch_Id = Convert.ToInt32(x.Branch_Id),
                Login_Id = Convert.ToInt32(x.Login_Id),
            }).SingleOrDefault();
            return View(mdworker);
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
            var data = from rg in db.Tbl_WorkerRegs
                       where rg.Email == email
                       select rg;
            if (data.Count() > 0)
            {
                return Json("");
            }
            else
            {
                return Json(data);
            }

        }

    }
}
