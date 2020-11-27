using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StoreApp.model;
using StoreApp.parser;
using StoreApp.repository;

namespace StoreApp.service
{
    public class GoodsService
    {
        public static void ВefineCategory(int category_id, out Category category)
        {
            category = null;
            switch (category_id)
            {
                case 1:
                    string book_category = "Book";
                    category = new Book(category_id, book_category);
                    break;
                case 2:
                    string clothes_category = "Clothes";
                    category = new Clothes(category_id, clothes_category);
                    break;
                case 3:
                    string food_category = "Food";
                    category = new Food(category_id, food_category);
                    break;
                default:
                    Console.Write("There is no such category!");
                    break;
            }
        }

        public static void AddProduct()
        {
            EnterCategory(out int category_id);

            GoodsService.ВefineCategory(category_id, out Category category);

            EnterTitle(out string name_input);
            EnterPrice(out decimal price);

            JsonParser.goodsRepository.GoodsList.Add(new Goods(name_input, category, price));
            File.WriteAllText(JsonParser.jsonPath, JsonConvert.SerializeObject(JsonParser.goodsRepository));

            Console.WriteLine("Product added!");

        }

        private static void EnterCategory(out int category_id)
        {
            Console.WriteLine("Enter the product category number:\n" +
                "1 - Book\n" +
                "2 - Clothes\n" +
                "3 - Food\n");
            string category_input = Console.ReadLine();
            category_id = int.Parse(category_input);
        }

        private static void EnterTitle(out string name_input)
        {
            Console.WriteLine("Enter the title:");
            name_input = Console.ReadLine();
        }

        private static void EnterPrice(out decimal price)
        {
            Console.WriteLine("Enter the price:");
            string price_input = Console.ReadLine();
            price = decimal.Parse(price_input);
        }

        public static void ViewCategoryGoods()
        {
            EnterCategory(out int category_id);
            foreach (Goods goodsEl in JsonParser.goodsRepository.GoodsList)
            {
                if (goodsEl.Category.Id == category_id)
                {
                    Console.WriteLine(goodsEl);
                }
            }
        }
        public static void ViewAllGoods()
        {
            JsonParser.goodsRepository.GoodsList.ForEach(Console.WriteLine);
            foreach (Goods goodsEl in JsonParser.goodsRepository.GoodsList) ;
        }

        public static void DeleteCategoryGoods()
        {
            EnterCategory(out int category_id);
            JsonParser.goodsRepository.GoodsList.RemoveAll(product => product.Category.Id == category_id);
            File.WriteAllText(JsonParser.jsonPath, JsonConvert.SerializeObject(JsonParser.goodsRepository));

            Console.WriteLine("Products deleted!");
        }
    }
}