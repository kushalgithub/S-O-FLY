using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
using MvcApplication2.Filters;
using System.Net;
using System.Net.Mail;


namespace MvcApplication2.Controllers
{
    public class ComplainController : Controller
    {
        //
        // GET: /Complain/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.Tbl_Complains.ToList());
        }


        public ActionResult WorIndex()
        {
            return View(db.Tbl_Complains.ToList());
        }


        [CustomAuthorization_User(LoginPage = "~/Login/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model_Complain com)
        {

            string id = Session["UserLoginId"].ToString();
            Tbl_Complain tbcom = new Tbl_Complain();
            tbcom.Complain_Id = com.Complain_Id;
            tbcom.User_Id = Convert.ToInt32(id);
            tbcom.Complain = com.Complain;
                       
            db.Tbl_Complains.InsertOnSubmit(tbcom);
            db.SubmitChanges();
            return RedirectToAction("my","User");
        }


        public ActionResult Delete(Int32 id)
        {
            Model_Complain mdcom = db.Tbl_Complains.Where(x => x.Complain_Id == id).Select(x => new Model_Complain()
            {
                Complain_Id = x.Complain_Id,
                Complain = x.Complain,
                User_Id = Convert.ToInt32(x.User_Id),
                UserName = x.Tbl_UserReg.UserName,
                Reply = x.Reply,
                
            }).SingleOrDefault();
            return View(mdcom);
        }

        [HttpPost]
        public ActionResult Delete(Int64 id)
        {
            Tbl_Complain tbcom = db.Tbl_Complains.Where(x => x.Complain_Id == id).Single<Tbl_Complain>();
            db.Tbl_Complains.DeleteOnSubmit(tbcom);
            db.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(Int32 id)
        {
            Model_Complain mdcom = db.Tbl_Complains.Where(x => x.Complain_Id == id).Select(x => new Model_Complain()
            {
                Complain_Id = x.Complain_Id,
                Complain = x.Complain,
                User_Id = Convert.ToInt32(x.User_Id),
                UserName = x.Tbl_UserReg.UserName,
                Reply = x.Reply,

            }).SingleOrDefault();
            return View(mdcom);
        }

        [HttpPost]
        public ActionResult Details(Model_Complain com)
        {
            Tbl_Complain tbcom = db.Tbl_Complains.Where(x => x.Complain_Id == com.Complain_Id).Single<Tbl_Complain>();
            tbcom.Complain_Id = com.Complain_Id;
            tbcom.Complain = com.Complain;
            tbcom.Reply = com.Reply;
           // tbcom.User_Id = com.User_Id;
            

            db.SubmitChanges();
            SendMail(tbcom.Tbl_UserReg.Email,"","Complain Reply",com.Reply,"");
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







    }


    }

