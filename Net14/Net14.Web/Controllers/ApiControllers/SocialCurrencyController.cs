using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Services;
using Net14.Web.Models.SocialModels.Attributes;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SocialAPI]

    public class SocialCurrencyController : Controller
    {
        private CurrencyService _currencyService;
        public SocialCurrencyController(CurrencyService currencyService) 
        {
            _currencyService = currencyService;
        }

        public IActionResult GetCurrency(string cur) 
        {
            var model = _currencyService.GetCurrency(cur);
            return Json(model);

        }
    }
}
