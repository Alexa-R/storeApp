using System;
using System.IO;
using Newtonsoft.Json;
using StoreApp.model;
using StoreApp.parser;
using StoreApp.repository;

namespace StoreApp.service
{
    public class Menu
    {
        public void RunMenu()
        {
            Console.WriteLine("Welcome to the program!\n" + "\"S\" - To get started\n" + "\"E\" - To exit");
            string input = Console.ReadLine();
            JsonParser.ReadJson();
            while (!"E".Equals(input))
            {
                Console.WriteLine("What do you want to do?" +
                        "\n1 - to see all products;" +
                        "\n2 - to see all products of a certain category;" +
                        "\n3 - to add new product;" +
                        "\n4 - to delete all products of a certain category" +
                        "\nWrite the symbol you want!");
                input = Console.ReadLine();
                switch (input)
                {
                    case ("1"):
                        {
                            GoodsService.ViewAllGoods();
                        }
                        break;
                    case ("2"):
                        {
                            GoodsService.ViewCategoryGoods();
                        }
                        break;
                    case ("3"):
                        {
                            GoodsService.AddProduct();
                        }
                        break;
                    case ("4"):
                        {
                            GoodsService.DeleteCategoryGoods();
                        }
                        break;
                    default:
                        Console.WriteLine("Unfortunately, there is no such action in the program! Please, try again.");
                        break;
                }
                Console.WriteLine("\nDo you want to continue?" +
                        "\n      Y - to continue" +
                        "\n      E - to exit");
                input = Console.ReadLine();

            }
            Console.WriteLine("Good bye!");
        }
    }
}
