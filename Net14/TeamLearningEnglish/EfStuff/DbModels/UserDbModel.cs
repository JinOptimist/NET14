using static TeamLearningEnglish.Models.EnglishLevel;
using System.Collections.Generic;
using TeamLearningEnglish.Models;
using System;
using System.ComponentModel.DataAnnotations;
using static TeamLearningEnglish.Models.Role;

namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class UserDbModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public Level EnglishLevel { get; set; }
        public Roles SiteRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
