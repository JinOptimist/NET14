using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel.CalendarDbModels
    
{
    [Flags]
    public enum Roles
    {
        Guest = 1,
        User = 2,
        Admin = 4,
    }
}
