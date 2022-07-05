using static TeamLearningEnglish.Models.EnglishLevel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using TeamLearningEnglish.Models.CustomValidationAttribute;

namespace TeamLearningEnglish.Models
{
    public class UserAuthenticationViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }
        public int Age { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Укажите возраст")]
        [IsPositiveAge]
        public DateTime? BirthDate { get; set; }
        public Level EnglishLevel { get; set; }
        [Required(ErrorMessage = "Введите email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(8,ErrorMessage ="Пароль должен содержать мин. 8 символов") ]
        public string Password { get; set; }

    }
}
