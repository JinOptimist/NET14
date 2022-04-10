using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.Calendar.Test
{
    public class TestCalendarUserRegistration
    {
        [Required(ErrorMessage = "Enter Name!")]
        public string Name { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Email!")]
        public string Email { get; set; }


    }
}
