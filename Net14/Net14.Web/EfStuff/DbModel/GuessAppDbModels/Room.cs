using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.GuessAppDbModels.Enums;

namespace Net14.Web.EfStuff.DbModel.GuessAppDbModels
{
    public class Room : BaseModel
    {
        public virtual List<UserSocial> Members { get; set; }
        public virtual UserSocial Creator { get; set; }
        public bool IsCompleted { get; set; }
        public RoomType Type { get; set; }
    }
}
