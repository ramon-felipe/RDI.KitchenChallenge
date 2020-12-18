using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class DrinkArea : KitchenArea, IKitchenArea
    {
        private static IReadOnlyDictionary<ItemSizeEnum, int> _CookTime = new Dictionary<ItemSizeEnum, int>()
        {
            { ItemSizeEnum.XSMALL, 1000 },
            { ItemSizeEnum.SMALL, 1200 },
            { ItemSizeEnum.MEDIUM, 1800 },
            { ItemSizeEnum.BIG, 2000 },
            { ItemSizeEnum.XBIG, 2300 },
        };
        public static DrinkArea Instance { get; set; }
        private DrinkArea() : base(_CookTime) { }

        public static DrinkArea GetInstance()
        {
            if (null == Instance)
                Instance = new DrinkArea();

            return Instance;
        }
    }
}
