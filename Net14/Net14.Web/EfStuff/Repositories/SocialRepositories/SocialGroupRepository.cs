using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialGroupRepository : BaseRepository<GroupSocial>
    {
        public SocialGroupRepository(WebContext context) :base(context)
        {

        }

        public void RemoveMember(int groupId, int userId) 
        {
            var group = _webContext.GroupSocial
                .FirstOrDefault(group => group.Id == groupId);
            var user = _webContext.Users.FirstOrDefault(user => user.Id == userId);
            group.Members.Remove(user);
            user.Groups.Remove(group);
            _webContext.SaveChanges();
        }

        public void AddPost(PostSocial post, int id) 
        {
            var group = _webContext.GroupSocial
                .SingleOrDefault(group => group.Id == id);
            group.Posts.Add(post);
            _webContext.SaveChanges();

        }

        public List<GroupSocial> GetGroupsByName(string name) 
        {
            var groups = _webContext.GroupSocial
                .Where(group => group.Name.ToLower() == name.ToLower()).ToList();

            return groups;
        }

        public void Subscribe(int groupId, int userId) 
        {
            var group = _webContext.GroupSocial.SingleOrDefault(group => group.Id == groupId);
            var user = _webContext.Users.SingleOrDefault(user => user.Id == userId);
            group.Members.Add(user);
            _webContext.SaveChanges();
        }

        public void Unsubscribe(int groupId, int userId) 
        {
            var group = _webContext.GroupSocial.SingleOrDefault(group => group.Id == groupId);
            var user = _webContext.Users.SingleOrDefault(user => user.Id == userId);
            group.Members.Remove(user);
            _webContext.SaveChanges();
        }

        public List<GroupSocial> GetUsersGroups(int userId) 
        {
            return _webContext.GroupSocial
                .Where(group => group.Members.Any(user => user.Id == userId))
                .ToList();
        }
    }
}
