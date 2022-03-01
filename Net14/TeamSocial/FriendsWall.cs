using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb;
using System.Linq;
namespace TeamSocial
{
    public class FriendsWall
    {
        public Social social;
        private User _currentUser;
        public FriendsWall(User user)
        {
            _currentUser = user;
            social = user.social;
        }
        public List<User> GetFriends()
        {
            return _currentUser.friends;
        }
        public bool AddFriendByEmail(string email)
        {
            var userWhichIsAdded = social.users.SingleOrDefault(user =>
            user.Email == email);

            if (userWhichIsAdded == null)
            {
                return false;
            }
            else if (_currentUser.friends.Contains(userWhichIsAdded))
            {
                return false;
            }
            else
            {
                _currentUser.friends.Add(userWhichIsAdded);
                userWhichIsAdded.friends.Add(_currentUser);
                return true;
            }
        }

        public bool AddFriend(User userWhichIsAdded)
        {
            if (_currentUser.friends.Contains(userWhichIsAdded))
            {
                return false;
            }
            else
            {
                _currentUser.friends.Add(userWhichIsAdded);
                userWhichIsAdded.friends.Add(_currentUser);
                return true;
            }
        }

        public bool DeleteFromFriendsByEmail(string email)
        {
            var userToDelete = social.users.SingleOrDefault(user =>
            user.Email == email);
            if (!_currentUser.friends.Contains(userToDelete))
            {
                return false;
            }
            else
            {
                _currentUser.friends.Remove(userToDelete);
                userToDelete.friends.Remove(_currentUser);
                return true;
            }
        }

        public bool DeleteFromFriends(User user)
        {
            if (!_currentUser.friends.Contains(user))
            {
                return false;
            }
            else
            {
                _currentUser.friends.Remove(user);
                user.friends.Remove(_currentUser);
                return true;
            }
        }

        public IEnumerable<User> RecomendationOfFriends()
        {
            var usersThatHaveTheSameFriends = social.users.Where(user  //Find users with the same friends
                => user.friends
                .Intersect(_currentUser.friends).Count() > 0)
                .Where(user => user != _currentUser)
                .ToList();
                 
            var usersWithTheSameCountryAndCity = social.users.Where(user => //Find users from the same country and the same city
            user.Country == _currentUser.Country && user.City == _currentUser.City).ToList();

            var usersWithTheSameCountry = social.users.Where(user => //Find users from different city, but from the same country
            user.Country == _currentUser.Country).ToArray();

            var resultrecomendation = usersWithTheSameCountryAndCity //Result array
                .Concat(usersWithTheSameCountry) //Сombine usersWithTheSameCountryAndCity with usersWithTheSameCountry
                .Concat(usersThatHaveTheSameFriends)// Combine with usersThatHaveTheSameFriends
                .OrderBy(user => Math.Abs(_currentUser.Age - user.Age)) //Order by age. The closer to the age of the user, the higher in the list.
                .OrderByDescending(user => user.friends.Intersect(_currentUser.friends).Count()) //Order by the count of the same friends
                .Distinct() //Delete users that repeats
                .Where(user => user != _currentUser).ToList(); //Select all users except _currrentuser

            return resultrecomendation;
        }
    }
}
