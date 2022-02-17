using System;
using System.Collections.Generic;
using System.Text;
using Team_Store.Category;

namespace Team_Store
{
    public class Menu
    {
        public void Draw()
        {
            var CategoryNameList = new List<GoodsCategory>();

            var electronics = new Electronics();
            CategoryNameList.Add(electronics);

            var products = new Products();
            CategoryNameList.Add(products);

            var cars = new Cars();
            CategoryNameList.Add(cars);

            var clothes = new Clothes();
            CategoryNameList.Add(clothes);

            var furniture = new Furniture();
            CategoryNameList.Add(furniture);

            var sport = new Sport();
            CategoryNameList.Add(sport);

            foreach (var cat in CategoryNameList)
            {
                Console.WriteLine(cat.CategoryName);
            }
        }
    }
}
