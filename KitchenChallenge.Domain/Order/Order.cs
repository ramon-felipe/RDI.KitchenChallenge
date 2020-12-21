using KitchenChallenge.Domain.Dishes;
using System.Collections.Generic;
using System.Linq;

namespace KitchenChallenge.Domain.Order
{
    public class Order
    {
        public decimal Amount {
            get { return Items.Sum(i => i.Price); ; }
        }
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            var output = "";
            var count = 0;
            this.Items.ForEach(i => {
                count++;
                output += $"{count} - Description: {i.Description} - {i.Size} - $ {i.Price}\n";
            });

            return output;
        }
    }
}
