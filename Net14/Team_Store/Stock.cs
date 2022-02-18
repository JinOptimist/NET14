using System;
using System.Collections.Generic;
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
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Amount);
                Console.WriteLine(item.Category);
            }
        }
    }
}

