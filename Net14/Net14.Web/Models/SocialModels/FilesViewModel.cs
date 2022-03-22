using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class FilesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Тестовый, дефолтный файл";
        public string Url { get; set; } = "https://auto.ironhorse.ru/wp-content/uploads/2020/10/m3-g80-front.jpg";
        public string Text { get; set; } = "Быстрая и мощная авто";

    }
}