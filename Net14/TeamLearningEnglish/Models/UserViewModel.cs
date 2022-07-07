using static TeamLearningEnglish.Models.EnglishLevel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamLearningEnglish.Models.CustomValidationAttribute;

namespace TeamLearningEnglish.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }     
        [Required(ErrorMessage= "Введите email")]
        [EmailVerification]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [PasswordVerification]
        public string Password { get; set; }
        public Level EnglishLevel { get; set; }
        public List<MessageViewModel> Messages { get; set; }

    }
}
