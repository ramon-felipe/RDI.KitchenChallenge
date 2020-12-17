using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using System;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class DrinkArea : IKitchenArea
    {
        public static DrinkArea Instance { get; set; }
        private DrinkArea() { }

        public static DrinkArea GetInstance()
        {
            if (null == Instance)
                Instance = new DrinkArea();

            return Instance;
        }

        public async Task PrepareItemAsync(Item item)
        {
            Console.WriteLine($"Preparing desert ({item.Description})...");

            await Task.Delay(1000);

            Console.WriteLine($"Desert ({item.Description}) done!");
        }
    }
}
