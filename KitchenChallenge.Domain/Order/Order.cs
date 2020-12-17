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
        public decimal Amount { get; set; }
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            var output = "";
            var count = 0;
            this.Items.ForEach(i => {
                count++;
                output += $"{count} - Description: {i.Description} - {i.Size}\n";
            });

            return output;
        }
    }
}
