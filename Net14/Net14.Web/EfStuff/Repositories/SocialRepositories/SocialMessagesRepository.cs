using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialMessagesRepository : BaseRepository<SocialMessages>
    {
        public SocialMessagesRepository(WebContext context) : base(context)
        {
        }

    }
}
