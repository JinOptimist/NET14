using Net14.Web.EfStuff.DbModel.GuessAppDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories.GuessArtRepositories
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(WebContext context) : base(context)
        {

        }

        public bool JoinRoom(UserSocial user, Room room)
        {
            if (room.Members.Any(member => member.Id == user.Id))
            {
                return false;
            }

            room.Members.Add(user);
            _webContext.SaveChanges();
            return true;
        }

        public bool LeaveGroup(UserSocial user, Room room) 
        {
            if (!room.Members.Any(member => member.Id == user.Id)) 
            {
                return false;
            }
            room.Members.Remove(user);
            _webContext.SaveChanges();
            return true;
        }
    }
}
