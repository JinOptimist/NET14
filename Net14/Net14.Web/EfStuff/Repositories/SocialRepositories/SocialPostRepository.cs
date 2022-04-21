using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialPostRepository : BaseRepository<PostSocial>
    {
        public SocialPostRepository(WebContext context) : base(context)
        {
        }
        public void RemovePost(int idPost)
        {
            var post = _webContext.Posts
                .SingleOrDefault(post => post.Id == idPost); //находим по id поста данный пост
                

            _webContext.Posts.Remove(post); // удаляем его 
            _webContext.SaveChanges();
        }
    }
}
