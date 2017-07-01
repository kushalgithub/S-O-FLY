using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_SubCategory_tbl
    {
        public int SubCategory_Id { get; set; }
        [Required]
        public string SubCateName { get; set; }
        public string SubCateDiscription { get; set; }
        public int Category_Id { get; set; }
    }
}