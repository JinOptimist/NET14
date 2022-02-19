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
    }
}
