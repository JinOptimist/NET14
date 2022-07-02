using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;

namespace TeamLearningEnglish.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(UserRepository userRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserDbModel GetCurrent()
        {
            var idStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Id")
                ?.Value;
            if(idStr == null)
            {
                return null;
            }
            int id = Int32.Parse(idStr);

            return  _userRepository.Get(id);
        }
    }
}
