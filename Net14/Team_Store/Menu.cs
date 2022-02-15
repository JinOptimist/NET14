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

            foreach (var cat in CategoryNameList)
            {
                Console.WriteLine(cat.CategoryName);
            }
         }
    }
}
