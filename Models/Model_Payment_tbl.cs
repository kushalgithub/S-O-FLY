using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Payment_tbl
    {
        public int Payment_Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        public string Service { get; set; }
        public string Charge { get; set; }
        public string Payment_Date { get; set; }
        public string Payment_Type { get; set; }
        public string Cheque_No { get; set; }
        public string Bank { get; set; }
    }
}