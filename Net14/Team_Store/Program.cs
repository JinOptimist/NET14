using System;

namespace Team_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            //var basket = new Basket();
            //Goods good1 = new Goods("Audi", 10, "Cars", 1000);
            //Goods good2 = new Goods("Opel", 5, "Cars", 3000);
            //Goods good3 = new Goods("BMW", 2, "Cars", 5000);
            //Goods good4 = new Goods("iPhone", 10, "Phones", 1000);
            //Goods good5 = new Goods("Samsung", 10, "Phones", 1000);
            //Goods good6 = new Goods("Xiaomi", 100, "Phones", 500);
            //Goods good7 = new Goods("Cake", 2, "Products", 10);
            //Goods good8 = new Goods("Sausage", 10, "Products", 5);
            //Goods good9 = new Goods("Cucumber", 23, "Products", 3);
                               
            //basket.Add(good8);
            //basket.Add(good8);
            //basket.Add(good3);
            //basket.Clear();
            //basket.Show();
            //Console.ReadKey();
              
            //var menu = new Menu();
            //menu.Start();  
            var menu = new Menu();
            menu.Start();
            menu.DrawCategories();
        }
    }
}
