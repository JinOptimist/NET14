using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class ImageRepository
    {
        private WebContext _webContext;

        public ImageRepository(WebContext context)
        {
            _webContext = context;
        }

        public Image Get(int id)
        {
            return _webContext
                .Images
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Image> GetAll()
        {
            return _webContext.Images.ToList();
        }

        public void Save(Image image)
        {
            _webContext.Images.Add(image);
            _webContext.SaveChanges();
        }
    }
}
