using System;

namespace Team_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.Start();
            menu.DrawCategories();
        }
    }
}
