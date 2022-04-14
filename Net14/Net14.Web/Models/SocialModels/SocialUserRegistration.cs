using Net14.Web.Models.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialUserRegistration
    {
        [Required(ErrorMessage = "Enter Email!")]
        [IsUniqEmail]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are't the same")]
        [Required(ErrorMessage ="Confirm password!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Enter City!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Country!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Age!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter FirstName!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter LastName!")]
        public string LastName { get; set; }
    }
}

