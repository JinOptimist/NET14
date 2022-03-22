﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class SocialUserAutorization
    {
        [Required(ErrorMessage = "Enter Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }

    }
}

