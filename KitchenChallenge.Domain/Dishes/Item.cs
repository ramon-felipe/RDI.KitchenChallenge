using KitchenChallenge.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenChallenge.Domain.Dishes
{
    public class Item
    {
        public ItemType Type { get; set; }
        public ItemSizeEnum Size { get; set; }
        public string Description { get; set; }
    }
}
