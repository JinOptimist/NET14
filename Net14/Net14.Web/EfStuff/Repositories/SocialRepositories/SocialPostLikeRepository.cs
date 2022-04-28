using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialPostLikeRepository : BaseRepository<PostSocial>
    {
        public SocialPostLikeRepository(WebContext context) : base(context)
        {
        }
    }
}
