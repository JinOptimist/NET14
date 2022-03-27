using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb;
using System.Linq;

namespace TeamSocial
{
    class Recomendation
    {
        private User _currentUser;
        public Recomendation(User user) 
        {
            _currentUser = user;
        }

        public IEnumerable<User> GetAgeRate(IEnumerable<User> users) //Рейтинг по возрасту
        {
            foreach (User user in users) 
            {
                user.RecomendationPercentage = 0;
                var differentInAge = Math.Abs(_currentUser.Age - user.Age);
                if (differentInAge == 0)
                {
                    user.RecomendationPercentage += (int)RecPropertiesWeight.Age;
                }
                else if (differentInAge <= 5)
                {
                    user.RecomendationPercentage += (int)RecPropertiesWeight.Age / 2;
                }
                else if (differentInAge <= 10 && differentInAge > 5)
                {
                    user.RecomendationPercentage += (int)RecPropertiesWeight.Age / 4;
                }
                else if (differentInAge <= 15 && differentInAge > 10) 
                {
                    user.RecomendationPercentage += (int)RecPropertiesWeight.Age / 5;
                }
            }
            return users;
        }

        public IEnumerable<User> GetCityRate(IEnumerable<User> users) 
        {
            foreach (User user in users) 
            {
                if (_currentUser.City.ToLower() == user.City.ToLower()) 
                {
                    user.RecomendationPercentage += (int)RecPropertiesWeight.City;
                }
            }
            return users;
        }

        public IEnumerable<User> GetCountryRate(IEnumerable<User> users) 
        {
            foreach (User user in users) 
            {
                if (_currentUser.Country.ToLower() == user.Country.ToLower());
            }
            return users;
        }

        public IEnumerable<User> GetSameFriendRate(IEnumerable<User> users) 
        {
            foreach (User user in users) 
            {
                var HaveTheSameFriends = user.friends.Intersect(_currentUser.friends).Count();
                user.RecomendationPercentage += (int)RecPropertiesWeight.SameFriends * HaveTheSameFriends;
            }
            return users;
        }

        public IEnumerable<User> GetRecomendation(IEnumerable<User> users) 
        {
            GetAgeRate(users);
            GetCityRate(users);
            GetCountryRate(users);
            GetSameFriendRate(users);
            var res = users.Where(user => user != _currentUser).OrderByDescending(user => user.RecomendationPercentage);

            return res;
        } 
    }
}
