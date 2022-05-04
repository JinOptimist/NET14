using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Models.CustomValidationAttribute;

namespace Net14.Web.Models
{
    public class SocialUserSettingsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [MyRange(5,120)]
        public int Age { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }


    }
}