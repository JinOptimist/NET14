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
            var CategoryNames = new List<GoodsCategory>();

            var electronics = new Electronics();
            CategoryNames.Add(electronics);

            var products = new Products();
            CategoryNames.Add(products);

            foreach (var cat in CategoryNames)
            {
                Console.WriteLine(cat.CategoryName);
            }
         }
    }
}
