using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Net14.Web.Models.CustomValidationAttribute
{
    public class NameAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"{name} can't contain numbers";
        }

        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(string))
            {
                throw new ValidationException("Must be string!");
            }

            return Validate(value.ToString());
        }

        public bool Validate(string name) 
        {
            bool res = false;
            foreach (char c in name) 
            {
                res = !(Char.IsDigit(c));
            }

            return res;
        }
    }
}
