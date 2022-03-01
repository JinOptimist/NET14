using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Team_Store
{
    class Stock
    {

        public List<Goods> goods { get; set; } = new List<Goods>();


        public void Add_Good()
        {
            var thing_to_stock = new Goods();
            thing_to_stock.product_description();
            goods.Add(thing_to_stock);


        }



        public void Show_Stock()
        {
            foreach (var item in goods)
            {
                Console.WriteLine($"Name:{item.Name}");
                Console.WriteLine($"Price:{item.Price}");
                Console.WriteLine($"Amount:{item.Amount}");
                Console.WriteLine($"Category:{item.Category}");
            }
        }

        public void SortByCategory()
        {
            Console.WriteLine("Enter name of category for search: ");
            var input = Console.ReadLine();

            foreach (var item in goods)
            {
                if (item.Category == input)
                {

                    Console.WriteLine($"Name:{item.Name}");
                    Console.WriteLine($"Price:{item.Price}");
                    Console.WriteLine($"Amount:{item.Amount}");
                    Console.WriteLine($"Category:{item.Category}");

                }
            }
        }
    }
}