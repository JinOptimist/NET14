using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Net14.Web.Models.CustomValidationAttribute
{
    public class EmailAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Incorrect email";
        }

        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(string))
            {
                throw new ValidationException("Must be string!");
            }

            //For program for user
            return Validate(value.ToString());
        }

        public bool Validate(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase) & emailAddress.Length > 0;
            return isValid;
        }
    }
}
