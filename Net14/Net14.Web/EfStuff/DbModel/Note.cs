using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.DbModel
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public int Importance { get; set; }
        public string DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public string Date { get; set; }
    }
}
