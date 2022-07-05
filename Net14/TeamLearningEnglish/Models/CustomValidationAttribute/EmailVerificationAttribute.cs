using System.ComponentModel.DataAnnotations;

namespace TeamLearningEnglish.Models.CustomValidationAttribute
{
    public class EmailVerificationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {





            return base.IsValid(value);
        }

    }
}
