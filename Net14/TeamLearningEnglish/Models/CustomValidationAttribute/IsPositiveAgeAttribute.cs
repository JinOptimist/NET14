using System;
using System.ComponentModel.DataAnnotations;

namespace TeamLearningEnglish.Models.CustomValidationAttribute
{
    public class IsPositiveAgeAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Возраст должен быть от 3 до 100 лет";
        }
        public override bool IsValid(object value)
        {
            DateTime dateBirth;
            
            if(value == null)
            {
                return false;
            }
            if (!DateTime.TryParse(value?.ToString(), out dateBirth))
            {
                throw new Exception("You can't use IsPositiveAttribute with not a DateTime");
            }

            int age = DateTime.Now.Subtract(dateBirth).Days;
            age = age / 360;

            return age >= 3 && age <= 100;
        }
        
    }
}
