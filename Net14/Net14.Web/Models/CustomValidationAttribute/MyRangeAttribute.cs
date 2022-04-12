using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.CustomValidationAttribute
{
    public class MyRangeAttribute : ValidationAttribute
    {
        private int _min;
        private int _max;

        public MyRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Sorry, but '{name}' must be more then {_min} and less then {_max}";
        }

        public override bool IsValid(object value)
        {
            int number;
            if (!int.TryParse(value?.ToString(), out number))
            {
                //For developer
                throw new Exception("You cann't use RangeAttribute with not a numbers");
            }

            //For program for user
            return number > _min && number < _max;
        }
    }
}
