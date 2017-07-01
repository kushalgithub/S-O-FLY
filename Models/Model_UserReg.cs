using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_UserReg
    {
        public int User_Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String FirstName { get; set; }
         [Required]
        public String LastName { get; set; }
         [Required]
        public String UserName { get; set; }
         [Required]
         [RegularExpression(@"^([a-zA-Z+]+[0-9+]+[&@!#+]+)$", ErrorMessage = "Use atleast one letter,character & number")]
         [Display(Name = "Password")]
        public String Password { get; set; }
         [Required]
         [System.Web.Mvc.Compare("Password", ErrorMessage = "Password and ConfirmPassword do not match")]
        public String ConfirmPassword { get; set; }
         [Required]
        public String Address { get; set; }
         [Required]
        public int Country_Id { get; set; }
         [Required]
        public int State_Id { get; set; }
         [Required]
        public int City_Id { get; set; }
         [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public String Email { get; set; }
         [Required]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
         
        public int ContactNumber { get; set; }
         
        public int Login_Id { get; set; }
    }
}