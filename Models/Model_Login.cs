using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Login
    {
        public int Login_Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z+]+[0-9+]+[&@!#+]+)$", ErrorMessage = "Use atleast one letter,character & number")]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [Required]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Password and ConfirmPassword do not match")]
        public string ConfirmPassword { get; set; }
    
    }
}