using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_BuyPart
    {
        public int Buy_Id { get; set; }
        public int Part_Id { get; set; }
        public int Category_Id { get; set; }
        public int SubCategory_Id { get; set; }
        public int Quantity { get; set; }
        public int User_Id { get; set; }
    }
}