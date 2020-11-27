using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StoreApp.model
{
    public class Goods
    {
        public string Title { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        public Goods(string title, Category category, decimal price)
        {
            Title = title;
            Category = category;
            Price = price;
        }

        public Goods()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Goods goods &&
                   Price == goods.Price &&
                   Title == goods.Title &&
                   EqualityComparer<Category>.Default.Equals(Category, goods.Category);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Title, Category);
        }

        public override string ToString()
        {
            return Category + " price = " + Price + ", title = " + Title;
        }
    }
}
