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
            var electronics = new Electronics();
            var categorymanes = new List<string>();

            var categoryName = electronics.WriteName()
            categorymanes.Add(electronics.WriteName());
            //categorymanes.Add(products.CategoryName);

            Console.WriteLine();
        }
        private void iewytgyu(GoodsCategory goodscategory)
        {
            var categoryName = goodscategory.WriteName()
        }
    }
}
