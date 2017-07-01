using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Model_Feedback
    {
        public int Feedback_Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public String  Feedback { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }
    }
}