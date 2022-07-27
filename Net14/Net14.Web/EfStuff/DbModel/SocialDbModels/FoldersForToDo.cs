using System;
using System.Collections.Generic;
using System.Linq;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class FoldersForToDo : BaseModel
    {
        public string Name { get; set; }
        public virtual List<IssuesForToDo> Issues { get; set; }

        
    }
}
