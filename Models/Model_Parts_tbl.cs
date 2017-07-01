using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Parts_tbl
    {
        public int Part_Id { get; set; }
        [Required]
        public string PartName { get; set; }
        public int Category_Id { get; set; }
        public int SubCategory_Id { get; set; }
        public string Part_No { get; set; }
        [Required]
        public string PartUsage { get; set; }
        [Required]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string PartPrice { get; set; }
        [Required]
        public string PartImage { get; set; }
        public int Quantity { get; set; }
    }
}