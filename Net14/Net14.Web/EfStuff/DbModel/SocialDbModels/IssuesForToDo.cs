using System;
using System.Collections.Generic;
using System.Linq;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class IssuesForToDo : BaseModel
    {
        public int IdIssue { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public virtual FoldersForToDo Folder { get; set; }
        
    }
}
