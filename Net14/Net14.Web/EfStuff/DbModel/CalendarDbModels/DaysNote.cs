using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class DaysNote : BaseModel
    {
        public string Text { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual CalendarUser CalendarUser { get; set; }
        
    }
}
