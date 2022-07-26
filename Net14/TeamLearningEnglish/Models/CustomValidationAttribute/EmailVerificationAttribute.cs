using System.ComponentModel.DataAnnotations;
using TeamLearningEnglish.EfStuff.Repository;

namespace TeamLearningEnglish.Models.CustomValidationAttribute
{
    public class EmailVerificationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            var email = value?.ToString();
            var repository = validationContext.GetService(typeof(UserRepository)) as UserRepository;
            var user = repository.GetByEmail(email);

            if (!user)
            {
                return new ValidationResult("Неверный email");
            }

            return ValidationResult.Success;
        }

    }
}
