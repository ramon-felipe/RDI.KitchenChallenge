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
        private static IReadOnlyDictionary<ItemSizeEnum, int> _CookTime;

        public KitchenArea(IReadOnlyDictionary<ItemSizeEnum, int> CookTime)
        {
            _CookTime = CookTime;
        }

        public async Task PrepareItemAsync(Item item)
        {            
            if (_CookTime.TryGetValue(item.Size, out int itemTime))
            {
                var itemSizeDesc = Enum.GetName(typeof(ItemType), item.Type);
                item.SetItemDescription(itemSizeDesc);
                
                Console.WriteLine($"Preparing {item.Description}. It takes {itemTime} milliseconds to be ready...");
                
                await Task.Delay(itemTime);
            }
            else
                throw new Exception($"{item.Description} cook time not defined");

            Console.WriteLine($"{item.Description} done!");
        }
    }
}
