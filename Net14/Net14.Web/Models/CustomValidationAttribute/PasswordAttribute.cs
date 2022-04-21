using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Net14.Web.Models.CustomValidationAttribute
{
    public class PasswordAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"At least 8 symbols";
        }

        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(string))
            {
                throw new ValidationException("Must be string!");
            }


            return value.ToString().Length >= 8;
        }
    }
}
