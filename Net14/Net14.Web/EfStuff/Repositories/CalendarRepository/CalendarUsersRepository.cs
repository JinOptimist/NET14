using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Net14.Web.EfStuff.Repositories
{
    public class CalendarUsersRepository : BaseRepository<CalendarUser>
    {
        public CalendarUsersRepository(WebContext context) : base(context)
        {
        }
        public CalendarUser GetByNameAndPass(string name, string pass)
        {
            var user = _webContext.CalendarUsers.Single(x => x.Name == name && x.Password == pass);
            return user;
        }
        public bool IsEmailExist(string email)
            => _dbSet.Any(x => x.Email == email);
    }
}
