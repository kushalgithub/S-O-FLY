using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_LoginAdmin
    {
        [Required]
        public string UserName { get;set; }
        [Required]
        public string Password { get; set; }
    }
}