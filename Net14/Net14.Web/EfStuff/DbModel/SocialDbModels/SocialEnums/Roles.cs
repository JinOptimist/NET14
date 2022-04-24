using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums
{
    [Flags]
    public enum Roles
    {
        Admin = 1,
        User = 2,
        StoreAdmin = 4,
        ImageAdmin = 8,
    }
}
