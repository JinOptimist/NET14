using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.ArtImage
{
    public class ShowCatigoriInfo
    {
        public AddCategoriVewModel Categori { get; set; }
        public List<AddSubCategoriVewModel> SubCategoris { get; set; }
    }
}
