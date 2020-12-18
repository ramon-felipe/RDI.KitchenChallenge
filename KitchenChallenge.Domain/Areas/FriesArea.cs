using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class FriesArea : KitchenArea, IKitchenArea
    {
        private static IReadOnlyDictionary<ItemSizeEnum, int> _CookTime = new Dictionary<ItemSizeEnum, int>()
        {
            { ItemSizeEnum.XSMALL, 1000 },
            { ItemSizeEnum.SMALL, 2000 },
            { ItemSizeEnum.MEDIUM, 3000 },
            { ItemSizeEnum.BIG, 4000 },
            { ItemSizeEnum.XBIG, 5000 },
        };
        public static FriesArea Instance { get; set; }
        private FriesArea() : base(_CookTime) { }

        public static FriesArea GetInstance()
        {
            if (null == Instance)
                Instance = new FriesArea();

            return Instance;
        }
    }
}
