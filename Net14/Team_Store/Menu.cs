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
            var CategoryNames = new List<string>();

            var electronics = new Electronics();
            GetName(electronics, CategoryNames);

            var products = new Products();
            GetName(products, CategoryNames);

            foreach (var item in CategoryNames)
            {
                Console.WriteLine(item);
            }
         }
        private void GetName(GoodsCategory goodscategory, List<string> list)
        {
            var categoryName = goodscategory.CategoryName;
            list.Add(categoryName);
        }
    }
}
