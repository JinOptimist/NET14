using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Store
{
    public class Basket
    {
        public List<Goods> Goods_in_Basket { get; set; }
        public void Add(Goods good)
        {
            
        }
            good.Amount_in_Basket++;
        }
        public void Remove(Goods good)
        {
            good.Amount_in_Basket = 0;
            Goods_in_Basket.Remove(good);
            
        }
        public void Show()
        {
            if (Goods_in_Basket.Count == 0)
            {
                Console.WriteLine("Your basket is empty.");
            }
            else
            {
                //Нужно с табуляциями что-то придумать
                Console.WriteLine("Your basket contains:");
                var cumulativePrice = 0;
                foreach (var good in Goods_in_Basket)
                {
                    var goodsList =
                        $"{good.Amount_in_Basket}x {good.Name}\t Price: {good.Price}\t Cumulative price: {good.Price * good.Amount_in_Basket}";
                    Console.WriteLine(goodsList);
            
                    cumulativePrice += good.Price * good.Amount_in_Basket;
                }
                var message =
                    $"\nCumulative price: {cumulativePrice}";
                Console.WriteLine(message);
        }
        }
        public void Clear()
        {
            
        }
        public void Buy()
        {
            
        }
    }
}
