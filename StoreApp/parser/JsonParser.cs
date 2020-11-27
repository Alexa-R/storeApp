using System;
using System.IO;
using Newtonsoft.Json;
using StoreApp.repository;

namespace StoreApp.parser
{
    public class JsonParser
    {
        public static GoodsRepository goodsRepository;
        public static string jsonPath { get; set; }
        public static void ReadJson()
        {
            EnterJsonPath();
            string myJsonString = File.ReadAllText(jsonPath);

            goodsRepository = JsonConvert.DeserializeObject<GoodsRepository>(myJsonString);
        }

        private static void EnterJsonPath()
        {
            Console.WriteLine("Enter the path to the JSON file with products(/folder/folder/file.json): ");
            jsonPath = Console.ReadLine();
            // "/Users/aleksandrarybakova/Projects/StoreApp/StoreApp/shop.json"
        }

    }
}
