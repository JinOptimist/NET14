using Net14.Web.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.CustomValidationAttribute
{
    public class IsUniqEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            //var typeSocialUserRepository = typeof(SocialUserRepository);
            //var serviceObj = validationContext.GetService(typeSocialUserRepository);
            //var serviceRepository = serviceObj as SocialUserRepository;
            //serviceRepository.Get(12);

            var socialUserRepository = 
                validationContext
                    .GetService(typeof(SocialUserRepository)) as SocialUserRepository;

            var email = value?.ToString();

            var isDuplicate = socialUserRepository.IsEmailExist(email);

            return isDuplicate 
                ? new ValidationResult("Email already is used")
                : ValidationResult.Success;
        }
    }
}
