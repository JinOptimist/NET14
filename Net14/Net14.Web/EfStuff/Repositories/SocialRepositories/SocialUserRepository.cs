using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;

namespace Net14.Web.EfStuff.Repositories
{
    public class SocialUserRepository : BaseRepository<UserSocial>
    {
        public SocialUserRepository(WebContext context) : base(context)
        {
        }

        public List<UserSocial> GetBy(string FullName = null, int Age = 0, string Country = null,
            string City = null, string FirstName = null, string LastName = null)
        {

            if (FullName == null)
            {
                var user = _webContext.Users.Where(userInDb =>
                    userInDb.Age == (Age == 0 ? userInDb.Age : Age) &&
                    userInDb.City.ToLower() == (City == null ? userInDb.City.ToLower() : City.ToLower()) &&
                    userInDb.Country.ToLower() == (Country == null ? userInDb.Country.ToLower() : Country.ToLower()) &&
                    userInDb.FirstName.ToLower() == (FirstName == null ? userInDb.FirstName.ToLower() : FirstName.ToLower()) &&
                    userInDb.LastName.ToLower() == (LastName == null ? userInDb.LastName.ToLower() : LastName.ToLower())).ToList();



                return user;
            }
            else
            {
                string[] names = FullName.Split(" ");
                if (names.Length == 1)
                {
                    var user = _webContext.Users.Where(user =>
                   user.FirstName.ToLower() == names[0].ToLower() || user.LastName.ToLower() == names[0].ToLower()).ToList();


                    return user;
                }
                else if (names.Length == 2)
                {
                    var user = _webContext.Users.Where(user =>
                    (user.FirstName.ToLower() == names[0].ToLower() && user.LastName.ToLower() == names[1].ToLower())
                        || (user.FirstName.ToLower() == names[1].ToLower() && user.LastName.ToLower() == names[0].ToLower())).ToList();

                    return user;

                }
                return null;
            }
        }

        public UserSocial GetByEmAndPass(string email, string pass)
        {
            var user = _webContext.Users.SingleOrDefault(x => x.Email == email && x.Password == pass);
            return user;
        }

        public bool IsEmailExist(string email)
            => _dbSet.Any(x => x.Email == email);

        public bool Exists(int userId)
        {
            return _webContext.Users.Any(user => user.Id == userId);
        }

        public bool ManageRole(int userId, SiteRole role)
        {
            var user = _webContext.Users.Single(user => user.Id == userId);
            if (user.Role.HasFlag(role))
            {
                user.Role &= ~role;
                _webContext.SaveChanges();
                return true;

            }

            user.Role |= role;
            _webContext.SaveChanges();
            return true;
        }

        public List<UserSocial> FindUserbyName(string name)
        {
            var users = _webContext.Users.Where(user
                => user.FirstName.ToLower().Contains(name) ||
                user.LastName.ToLower().Contains(name)).ToList();

            return users;
        }

        public bool AddPhoto(SocialPhoto photo, int userId)
        {
            var user = _webContext.Users.SingleOrDefault(user => user.Id == userId);
            if (user == null)
            {
                return false;
            }
            user.Photos.Add(photo);
            _webContext.SaveChanges();
            return true;
        }

        public bool DeleteFriend(UserSocial currentUser, UserSocial userToDelete) 
        {
            currentUser.Friends.Remove(userToDelete);
            userToDelete.Friends.Remove(currentUser);

            var friendRequest = _webContext.UserFriendRequests.Where(req =>
            req.Receiver.Id == currentUser.Id && req.Sender.Id == userToDelete.Id
            || req.Receiver.Id == userToDelete.Id && req.Sender.Id == currentUser.Id);

            _webContext.UserFriendRequests.RemoveRange(friendRequest);
            _webContext.SaveChanges();
            return true;
        }

        public bool MakeUserOnline(UserSocial userSocial) 
        {
            userSocial.IsOnline = true;
            _webContext.SaveChanges();
            return true;
        }

        public bool MakeUserNotOnline(UserSocial userSocial) 
        {
            userSocial.IsOnline = false;
            _webContext.SaveChanges();
            return true;
        }

        public UserSocial GetUserToReport(int id) 
        {
            return _webContext.Users
                .Include(user => user.Friends)
                .Include(user => user.Groups)
                    .ThenInclude(group => group.Members)
                .Include(user => user.Files)
                .Include(user => user.SendMessages)
                .Include(user => user.RecievedMessages)
                .FirstOrDefault(x => x.Id == id);
        }

    }
}
