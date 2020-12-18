using KitchenChallenge.Domain.Dishes;
using System.Collections.Generic;
using System.Linq;

namespace KitchenChallenge.Domain.Order
{
    public class Order
    {
        public uint Number { get; private set; }
        public decimal Amount { get; private set; }
        public List<Item> Items { get; set; }

        public void SetOrderNumber(uint number)
        {
            Number = number;
        }

        public void CalcOrderAmount(Order order)
        {
            Amount = order.Items.Sum(i => i.Price);
        }

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
