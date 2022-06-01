using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.SocialModels
{
    public class IssuesForToDoViewModel 
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int FolderId { get; set; }

    }
}
