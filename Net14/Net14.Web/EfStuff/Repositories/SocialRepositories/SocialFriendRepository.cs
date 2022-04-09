using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialFriendRepository : BaseRepository<UserFriend>
    {
        public SocialFriendRepository(WebContext context):base(context)
        {
        }
        public bool UserExists(int userId) 
        {
            return _webContext.Users.Any(user => user.Id == userId);
        }
        public List<UserSocial> FriendsIds(int userId)
        {
            if (UserExists(userId))
            {
                var friends = _webContext
                    .UserFriends
                    .Where(u => u.UserId == userId)
                    .Select(u => u.Friend)
                    .ToList();

                return friends;
            }
            else
            {
                return null;
            }
        }

    }
}
