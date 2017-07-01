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
    public class ForgotPwdController : Controller
    {
        //
        // GET: /ForgotPwd/

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
        public ActionResult Create(Model_UserReg cp)
        {
            
            Model_UserReg reg = db.Tbl_UserRegs.Where(x => x.Email == cp.Email).Select(x => new Model_UserReg()
            {
                Email = x.Email,
                User_Id = x.User_Id,
                Password = x.Password

            }).SingleOrDefault();
            if (reg != null)
            {
                SendMail(reg.Email, "", "Forgot Password", "Your Password :" + reg.Password, "");
                return RedirectToAction("Create");
            }

            else
            {
            return View();
            }
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
