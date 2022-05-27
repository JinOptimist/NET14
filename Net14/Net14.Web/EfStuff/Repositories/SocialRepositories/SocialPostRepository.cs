using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories.SocialRepositories;

namespace Net14.Web.EfStuff.Repositories
{
    public class SocialPostRepository : BaseRepository<PostSocial>, ISocialPostRepository
    {
        public SocialPostRepository(WebContext context) : base(context)
        {
        }

        public bool AddLike(PostSocial post, UserSocial currentUser)
        {
            if (post.Likes.Any(like => like.User.Id == currentUser.Id)) 
            {
                return false;
            }

            var like = new SocialLike()
            {
                Post = post,
                User = currentUser
            };

            post.Likes.Add(like);

            _webContext.SaveChanges();

            return true;
        }

        public bool RemoveLike(PostSocial post, UserSocial currentUser)
        {

            var like = post.Likes.SingleOrDefault(like => like.User.Id == currentUser.Id);
            if (like == null) 
            {
                return false;
            }
            post.Likes.Remove(like);

            _webContext.SaveChanges();

            return true;
        }
    }
}
