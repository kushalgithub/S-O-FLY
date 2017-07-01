using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Complain
    {
        public int Complain_Id {get; set;}
        [Required]
        public int User_Id { get; set; }
        [Required]
        public string Complain { get; set; }
        public string UserName { get; set; }
        public string Reply { get; set; }
    }
}