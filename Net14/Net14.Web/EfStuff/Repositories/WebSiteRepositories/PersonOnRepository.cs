using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class PersonOnRepository : BaseRepository<PersonDbModel>
    {
        public PersonOnRepository(WebContext context):base(context)
        {
        }
    }
}
