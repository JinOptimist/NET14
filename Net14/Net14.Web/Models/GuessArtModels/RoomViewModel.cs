using Net14.Web.EfStuff.DbModel.GuessAppDbModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.GuessArtModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int MembersCount { get; set; }
        public string Owner { get; set; }
        public RoomType Type { get; set; }
        public List<SocialUserViewModel> Members { get; set; }

    }
}
