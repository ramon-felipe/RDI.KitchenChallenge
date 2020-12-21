using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public abstract class KitchenArea
    {
        public async Task PrepareItemAsync(Item orderItem)
        {
            Console.WriteLine($"Preparing {orderItem.Description}. It takes {orderItem.CookTime} milliseconds to be ready...");
            await Task.Delay((int)orderItem.CookTime);
            Console.WriteLine($"{orderItem.Description} done!");
        }
    }
}
