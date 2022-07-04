using static TeamLearningEnglish.Models.EnglishLevel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamLearningEnglish.Models
{
    public class UserAuthenticationViewModel
    {
        [Required(ErrorMessage="Введите имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }
        public int Age { get; set; }     
        public Level EnglishLevel { get; set; }
        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

    }
}
