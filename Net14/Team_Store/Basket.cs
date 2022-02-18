using System;
using System.Collections.Generic;

namespace Team_Store
{
    public class Basket
    {
        private List<Goods> Goods_in_Basket = new List<Goods>();
        public void Add(Goods good)
        {
            if (Goods_in_Basket.Contains(good) == false)
            {
                Goods_in_Basket.Add(good);
            }
                good.Amount_in_Basket++;
        }
        public void Remove(Goods good)
        {
            Goods_in_Basket.Remove(good);
            good.Amount_in_Basket = 0;
        }
        public void Show()
        {
            //Нужно с табуляциями что-то придумать
            if (Goods_in_Basket.Count == 0)
            {
                Console.WriteLine("Your basket is empty.");
            }
            else
            {
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
            foreach (var good in Goods_in_Basket)
            {
                Goods_in_Basket.Remove(good);
                good.Amount_in_Basket = 0;
            }
        }
        public void Buy()
        {
            //Show();
        }
    }
}
