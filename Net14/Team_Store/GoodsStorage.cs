using System;
using System.Collections.Generic;
using System.Text;
using Team_Store.Category;

namespace Team_Store
{
    public class GoodsStorage
    {
        public void DefaultGoods(List<GoodsCategory> GoodsList)
        {
            var car1 = new Cars()
            {
                Name = "Lada",
                Price = 1000,
                Quantity = 5
            };
            GoodsList.Add(car1);

            var car2 = new Cars()
            {
                Name = "Opel",
                Price = 3000,
                Quantity = 3
            };
            GoodsList.Add(car2);

            var car3 = new Cars()
            {
                Name = "BMW",
                Price = 5000,
                Quantity = 2
            };
            GoodsList.Add(car3);
        }
        public void AddUserGoods(List<GoodsCategory> GoodsList)
        {
            Console.WriteLine("Enter Category...");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Машины":
                    Console.WriteLine("Enter Name...");
                    var Name = Console.ReadLine();
                    foreach (var item in GoodsList)
                    {
                        if (Name == item.Name)
                        {
                            Console.WriteLine("We have this good on our warehouse");

                            Console.WriteLine("Enter Quantity...");
                            var NewQuantity = Int32.Parse(Console.ReadLine());

                            item.Quantity += NewQuantity;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter Price...");
                            var Price = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Quantity...");
                            var Quantity = Int32.Parse(Console.ReadLine());

                            var car1 = new Cars()
                            {
                                Name = Name,
                                Price = Price,
                                Quantity = Quantity
                            };
                            GoodsList.Add(car1);
                        }
                    }

                    foreach (var item2 in GoodsList)
                    {
                        if (item2.Quantity == 0)
                        {
                            Console.WriteLine($"Name = {item2.Name}\n" +
                                $"Price = {item2.Price}\n" +
                                $"Out of storage...");
                        }
                        else
                        {
                            Console.WriteLine($"Name = {item2.Name}\n" +
                                $"Price = {item2.Price}\n" +
                                $"Quantity = {item2.Quantity}");
                        }
                    }
                    Console.ReadKey();
                    break;
            }

        }
    }
}
