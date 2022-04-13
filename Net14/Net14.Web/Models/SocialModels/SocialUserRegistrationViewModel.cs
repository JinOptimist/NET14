using Net14.Web.Models.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialUserRegistrationViewModel
    {
        [Required(ErrorMessage = "Enter Email!")]
        [Email]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        [Password]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords are't the same")]
        [Required(ErrorMessage ="Confirm password!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Enter City!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Country!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Age!")]
        [IsPositive]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter FirstName!")]
        [Name]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter LastName!")]
        [Name]
        public string LastName { get; set; }
    }
}

