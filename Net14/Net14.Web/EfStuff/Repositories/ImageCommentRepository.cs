using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class ImageCommentRepository
    {
        private WebContext _webContext;

        public ImageCommentRepository(WebContext context)
        {
            _webContext = context;
        }

        public void Save(ImageComment image)
        {
            _webContext.ImageComments.Add(image);
            _webContext.SaveChanges();
        }
    }
}
