using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Worker
    {
        public int Worker_Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        public int Country_Id { get; set; }
        public int State_Id { get; set; }
        public int City_Id { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public int Contact_No { get; set; }
        [Required]
        public string Email { get; set; }
        public int Branch_Id { get; set; }
        public int Login_Id { get; set; }
    }
}