using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class FriesArea : IKitchenArea
    {
        private IReadOnlyDictionary<ItemSizeEnum, int> friesCookTime = new Dictionary<ItemSizeEnum, int>()
        {
            { ItemSizeEnum.XSMALL, 500 },
            { ItemSizeEnum.SMALL, 1000 },
            { ItemSizeEnum.MEDIUM, 1500 },
            { ItemSizeEnum.BIG, 2000 },
            { ItemSizeEnum.XBIG, 2500 },
        };
        public static FriesArea Instance { get; set; }
        private FriesArea() { }

        public static FriesArea GetInstance()
        {
            if (null == Instance)
                Instance = new FriesArea();

            return Instance;
        }

        public async Task PrepareItemAsync(Item item)
        {
            Console.WriteLine($"Preparing fries ({item.Description})...");

            if(friesCookTime.TryGetValue(item.Size, out int friesTime))
            {
                await Task.Delay(friesTime);
            }
            else
            {
                throw new Exception("Fries cook time not defined");
            }

            Console.WriteLine($"Fries ({item.Description}) done!");
        }
    }
}
