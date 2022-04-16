using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.SocialModels
{
    public class CurrencyViewModel
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public float Cur_OfficialRate { get; set; }
        public List<(string, string)> CurNames = new List<(string,string)>
        {
            ("USD", "Dollar USA"),
            ("EUR", "Euro"),
            ("RUB", "Russian Rubles"),
            ("GBP", "Pound Sterling"),
            ("CNY", "Yuan")
        };
        public string Selected { get; set; }
    }
}
