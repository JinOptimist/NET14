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
    }
}
