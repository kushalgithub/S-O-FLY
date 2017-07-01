using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_ServiceApp
    {
        public int User_Id { get; set; }
        public int Service_Id { get; set; }
        [Required]
        public string Appointment_Date { get; set; }
        public string Problem { get; set; }
        public String UserName { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public int Branch_Id { get; set; }
    }
}