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
            var StarterMessage =
                "Интернет-магазин Вейшнория.\n" +
                "  Навигация по категориям производится стрелками на клавиатуре,\n" +
                "  Enter - выбрать категорию,\n" +
                "  Esc - выйти из категории.";
            Console.WriteLine(StarterMessage);
            Console.WriteLine("Нажмите любую клавишу,чтобы продолжить...");
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

            foreach (var cat in CategoryNameList)
            {
                Console.WriteLine(cat.CategoryName);
            }
            /* var key = Console.ReadKey();
             switch (key.Key)
             {
                 case ConsoleKey.Enter:
                     Console.Clear();
                     DrawCategories();
                     break;
                 case ConsoleKey.Escape:
                     Environment.Exit(0);
                     break;
             }*/
        }
    }
}
