using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenChallenge.Domain.Order
{
    public class Order
    {
        public uint Number { get; set; }
        public IKitchenArea KitchenArea { get; set; }
        public decimal Amount { get; set; }
        public List<Dish> Items { get; set; }
    }
}
