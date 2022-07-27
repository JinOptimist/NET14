using System.ComponentModel.DataAnnotations;
using TeamLearningEnglish.EfStuff.Repository;

namespace TeamLearningEnglish.Models.CustomValidationAttribute
{
    public class IsUniqEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var userRepository = validationContext.GetService(typeof(UserRepository)) as UserRepository;


            var email = value?.ToString();

            var isDuplicate = userRepository.IsEmailExist(email);
            if (isDuplicate)
            {
                return new ValidationResult("Такой email уже существует");
            }

            return ValidationResult.Success;

        }

    }
}
