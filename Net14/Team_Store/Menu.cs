using System;
using System.Collections.Generic;
using System.Text;
using Team_Store.Category;

namespace Team_Store
{
    public class Menu
    {
        public void Start()
        {
            var starterMessge =
                "\n  WebStore Veishnoria:\n" +
                "    Use keyboard arrows to navigate\n" +
                "    Enter - select category\n" +
                "    Esc - leave current category\n";
            Console.WriteLine(starterMessge);
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }
        public void DrawCategories()
        {
            Console.Clear();
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

            for (int i = 0; i < CategoryNameList.Count; i++)
            {
                Console.WriteLine($"  {i+1}. " + CategoryNameList[i].CategoryName);
            }

            var GoodsStorage = new GoodsStorage();
            var GoodsList = new List<GoodsCategory>();
            GoodsStorage.DefaultGoods(GoodsList);
            GoodsStorage.AddUserGoods(GoodsList);
        }
    }
}
