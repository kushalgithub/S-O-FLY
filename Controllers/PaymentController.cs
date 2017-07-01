using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;
namespace MvcApplication2.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View(db.Tbl_Payments.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Create(Model_Payment_tbl payment)
        {
            Tbl_Payment tbpayment = new Tbl_Payment();
            tbpayment.User_Id = payment.User_Id;
            tbpayment.Payment_Date = payment.Payment_Date;
            tbpayment.Payment_Type = payment.Payment_Type;
            tbpayment.Service = payment.Service;
            tbpayment.Charge = payment.Charge;
            tbpayment.Cheque_No = payment.Cheque_No;
            tbpayment.Bank = payment.Bank;
            db.Tbl_Payments.InsertOnSubmit(tbpayment);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Edit(int id)
         {
             Model_Payment_tbl mdpay = db.Tbl_Payments.Where(x => x.Payment_Id == id).Select(x => new Model_Payment_tbl()
             {
                 Payment_Id = x.Payment_Id,
                 User_Id = Convert.ToInt32(x.User_Id),
                 Service = x.Service,
                 Charge = x.Charge,
                 Payment_Date = x.Payment_Date,
                 Payment_Type = x.Payment_Type,
                 Cheque_No = x.Cheque_No,
                 Bank = x.Bank,
             }).SingleOrDefault();
             return View(mdpay);
         }

         [HttpPost]
         public ActionResult Edit(Model_Payment_tbl payment)
         {
             Tbl_Payment tbpayment = db.Tbl_Payments.Where(x => x.Payment_Id == payment.Payment_Id).Single<Tbl_Payment>();
             tbpayment.User_Id = payment.User_Id;
             tbpayment.Payment_Date = payment.Payment_Date;
             tbpayment.Payment_Type = payment.Payment_Type;
             tbpayment.Service = payment.Service;
             tbpayment.Charge = payment.Charge;
             tbpayment.Cheque_No = payment.Cheque_No;
             tbpayment.Bank = payment.Bank;
             
             db.SubmitChanges();
             return RedirectToAction("Index");
         }

         public ActionResult Delete(Int32 id)
         {
             Model_Payment_tbl mdpay = db.Tbl_Payments.Where(x => x.Payment_Id == id).Select(x => new Model_Payment_tbl()
             {
                 Payment_Id = x.Payment_Id,
                 User_Id = Convert.ToInt32(x.User_Id),
                 Service = x.Service,
                 Charge = x.Charge,
                 Payment_Date = x.Payment_Date,
                 Payment_Type = x.Payment_Type,
                 Cheque_No = x.Cheque_No,
                 Bank = x.Bank,
             }).SingleOrDefault();
             return View(mdpay);
         }

         [HttpPost]
         public ActionResult Delete(Int64 id)
         {
             Tbl_Payment tbpay = db.Tbl_Payments.Where(x => x.Payment_Id == id).Single<Tbl_Payment>();
             db.Tbl_Payments.DeleteOnSubmit(tbpay);
             db.SubmitChanges();
             return RedirectToAction("Index");

         }
    }
}
