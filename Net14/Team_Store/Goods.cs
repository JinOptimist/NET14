using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Store
{
    public class Goods
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Amount_in_Basket { get; set; }


        public Goods(string name, int amount, string category, int price)
        {
            Name = name;
            Amount = amount;
            Category = category;
            Price = price;
            Amount_in_Basket = 0;
        }

        public Goods()
        {

        }

        public void product_description()
        {
            Console.WriteLine("Enter Goods:\n\t 1) Name\n\t 2) Amount\n\t 3) Price \n\t 4) Category ");


            Name = Console.ReadLine();
            var Amountstr = Console.ReadLine();
            Amount = int.Parse(Amountstr);
            var Pricestr = Console.ReadLine();
            Price = int.Parse(Pricestr);
            Category = Console.ReadLine();


        }

    }
}
