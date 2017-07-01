using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Branch_tbl
    {
        public int Branch_Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Area_Id { get; set; }
        [Required]
        public string City_Id { get; set; }
        [Required]
        public string State_Id { get; set; }
        [Required]
        public string Country_Id{ get; set; }
        [Required]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Numbers only please")]
        public int Contact_No { get; set; }
        }
}