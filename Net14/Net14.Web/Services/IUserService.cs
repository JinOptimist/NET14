using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Services
{
    public interface IUserService
    {
        public UserSocial GetCurrent();
        public CalendarUser CalendarGetCurrent();
        public bool CalendarHasRole(Net14.Web.EfStuff.DbModel.CalendarDbModels.Roles role);
        public bool HasRole(SiteRole role);
        public bool IsAdmin();
        public bool IsStoreAdmin();
        public int GetUsersNotifications();

    }
}
