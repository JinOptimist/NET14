using System.ComponentModel.DataAnnotations;
using TeamLearningEnglish.EfStuff.Repository;

namespace TeamLearningEnglish.Models.CustomValidationAttribute
{
    public class PasswordVerificationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            var password = value?.ToString();
            var repository = validationContext.GetService(typeof(UserRepository)) as UserRepository;
            var user = repository.GetByPassword(password);

            if (!user)
            {
                return new ValidationResult("Неверный пароль");
            }

            return ValidationResult.Success;
        }

    }
}
