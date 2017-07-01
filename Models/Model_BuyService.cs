using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_BuyService
    {
        public int BuyService_Id { get; set; }
        public int Service_Id { get; set; }
        public int User_Id { get; set; }
        public int ServiceCharge { get; set; }
        public string Status { get; set; }
    }
}