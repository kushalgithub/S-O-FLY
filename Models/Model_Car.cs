using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Car
    {
        public int Car_Id { get; set; }
        [Required]
        public string Car_Model { get; set; }
        [Required]
        public string Car_No { get; set; }
        public int User_Id { get; set; }
    }
}