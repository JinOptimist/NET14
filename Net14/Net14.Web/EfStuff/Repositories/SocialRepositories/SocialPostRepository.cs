using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Services;

namespace Net14.Web.EfStuff.Repositories
{
    public class SocialPostRepository : BaseRepository<PostSocial>
    {
        public SocialPostRepository(WebContext context) : base(context)
        {
        }

        public void AddLike(int postId)
        {
            var post = _webContext.Posts.SingleOrDefault(x => x.Id == postId);
            post.Likes++;
            _webContext.SaveChanges();
        }
    }
}
