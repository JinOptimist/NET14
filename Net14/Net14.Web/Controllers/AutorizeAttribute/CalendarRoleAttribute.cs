using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14.Web.EfStuff.DbModel.CalendarDbModels;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Controllers.AutorizeAttribute
{
    public class CalendarRoleAttribute : ActionFilterAttribute
    {
        private Roles _roles;

        public CalendarRoleAttribute(Roles role)
        {
            _roles = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userService =
                context.HttpContext.RequestServices.GetService(typeof(UserService)) as UserService;

            if (userService.CalendarGetCurrent() == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!userService.CalendarHasRole(_roles))
            {
                context.Result = new ForbidResult("Недостаточно прав");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
