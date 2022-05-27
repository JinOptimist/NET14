using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories.SocialRepositories
{
    public interface ISocialGroupRepository : IBaseRepository<GroupSocial>
    {
        public void RemoveMember(int groupId, int userId);
        public void AddPost(PostSocial post, int id);
        public List<GroupSocial> GetGroupsByName(string name);
        public void Subscribe(int groupId, int userId);
        public void Unsubscribe(int groupId, int userId);
    }
}
