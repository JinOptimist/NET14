using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.Calendar
{
    public class TestNotesViewModel
    {
        public string Text { get; set; }
        public DateTime EventDate { get; set; }
        public virtual UserSocial CalendarUser { get; set; }
        
    }
}
