using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialFileRepository : BaseRepository<FileSocial>
    {
        public SocialFileRepository(WebContext context) : base(context)
        {
        }

        public List<FileSocial> GetUsersFiles(int userId) 
        {
            return _webContext.fileSocial
                .Where(file => file.Owner.Id == userId)
                .ToList();
        }

    }
}
