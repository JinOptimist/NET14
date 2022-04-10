using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Net14.Web.EfStuff.Repositories
{
    public class DaysNoteRepository : BaseRepository<DaysNote>
    {
        public DaysNoteRepository(WebContext context) : base(context)
        {
        }
    }
}
