using System;
using System.Collections.Generic;
using StoreApp.model;

namespace StoreApp.repository
{
    public class GoodsRepository
    {
        public List<Goods> GoodsList { get; set; }

        public GoodsRepository(List<Goods> goodsList)
        {
            GoodsList = goodsList;
        }

        public GoodsRepository()
        {
        }
    }
}
