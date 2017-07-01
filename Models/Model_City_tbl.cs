using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_City_tbl
    {
        public int City_Id { get; set; }
        [Required]
        public string City_Name { get; set; }
        public int State_Id { get; set; }
    }
}