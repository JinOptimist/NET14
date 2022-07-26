using System;
using System.ComponentModel.DataAnnotations;

namespace TeamLearningEnglish.Models
{
    public class Role
    {
        [Flags]
        public enum Roles
        {
            Admin = 1,
            User = 2,
        };

    }
}
