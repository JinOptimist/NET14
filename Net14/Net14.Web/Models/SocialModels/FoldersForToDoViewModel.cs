using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.SocialModels
{
    public class FoldersForToDoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IssuesForToDoViewModel> IssuesForToDo { get; set; }


    }
}
