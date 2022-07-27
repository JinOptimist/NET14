using Microsoft.AspNetCore.Http;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Localize
{
    public class LocalizeMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userService = context
                .RequestServices
                .GetService(typeof(UserService)) as UserService;

            var user = userService.GetCurrent();
            if (user != null)
            {
                switch (user.Language)
                {
                    case Language.Eng:
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("en-EN");
                        break;
                    case Language.Rus:
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("ru-RU");
                        break;
                }
            }
            else
            {
                var srLang = context.Request.Cookies["SmileLag"];
                Enum.TryParse(srLang, out Language lang);
                switch (lang)
                {
                    case Language.Eng:
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("en-EN");
                        break;
                    case Language.Rus:
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("ru-RU");
                        break;
                }
            }

            await _next(context);
        }
    }
}
