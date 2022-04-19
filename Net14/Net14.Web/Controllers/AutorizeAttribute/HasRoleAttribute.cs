using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers.AutorizeAttribute
{
    public class HasRoleAttribute : ActionFilterAttribute
    {
        private SiteRole _siteRole;

        public HasRoleAttribute(SiteRole siteRole)
        {
            _siteRole = siteRole;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userService =
                context.HttpContext.RequestServices.GetService(typeof(UserService)) as UserService;

            if (userService.GetCurrent() == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!userService.HasRole(_siteRole))
            {
                context.Result = new ForbidResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
