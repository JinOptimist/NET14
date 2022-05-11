using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;
using Net14.Web.Models;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class PersonDbModel: BaseModel
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }
        public string Url { get; set; }

    }
}
