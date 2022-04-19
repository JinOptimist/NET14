using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.Json;
using Net14.Web.Models.SocialModels;
//431 - USD

namespace Net14.Web.Services
{
    public class CurrencyService
    {
        public CurrencyViewModel GetCurrency(string cur)
        {
            WebRequest request = WebRequest.Create($"https://www.nbrb.by/api/exrates/rates/{cur}?parammode=2");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = reader.ReadToEnd();
                }
            }
            response.Close();

            CurrencyViewModel model = JsonSerializer.Deserialize<CurrencyViewModel>(answer);
            return model;
        }
    }
}
