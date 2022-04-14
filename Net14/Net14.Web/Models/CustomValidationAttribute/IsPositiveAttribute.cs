using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.CustomValidationAttribute
{
    public class IsPositiveAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Sorry, but '{name}' cann't be negative";
        }

        public override bool IsValid(object value)
        {
            int number;
            if (!int.TryParse(value?.ToString(), out number))
            {
                //For developer
                throw new Exception("You cann't use IsPositiveAttribute with not a numbers");
            }

            //For program for user
            return number > 0;
        }
    }
}
