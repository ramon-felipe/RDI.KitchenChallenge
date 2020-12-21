using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Dishes
{
    public class Item
    {
        public ItemType Type { get; set; }
        public ItemSizeEnum Size { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public uint CookTime { get; set; }
    }
}
