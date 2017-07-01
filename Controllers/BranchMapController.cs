using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Dbml;


namespace MvcApplication2.Controllers
{
    public class BranchMapController : Controller
    {
        //
        // GET: /BranchMap/
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(db.Tbl_Branches.ToList());
        }


    }
}
