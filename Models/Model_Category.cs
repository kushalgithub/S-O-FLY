using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Category
    {
        public int Category_Id { get; set; }
        [Required]
        public string Category_name { get; set; }
        public string Discription { get; set; }
    }
}