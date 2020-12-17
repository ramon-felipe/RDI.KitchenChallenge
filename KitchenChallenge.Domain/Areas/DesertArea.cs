using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class DesertArea : IKitchenArea
    {
        public static DesertArea Instance { get; set; }
        private DesertArea() {}

        public static DesertArea GetInstance()
        {
            if (null == Instance)
                Instance = new DesertArea();

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
