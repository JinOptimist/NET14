using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories.SocialRepositories
{
    public interface ISocialPostRepository : IBaseRepository<PostSocial>
    {
        public bool AddLike(PostSocial post, UserSocial currentUser);
        public bool RemoveLike(PostSocial post, UserSocial currentUser);

    }
}
