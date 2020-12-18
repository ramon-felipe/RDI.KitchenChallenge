using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class SaladArea : KitchenArea, IKitchenArea
    {
        private static IReadOnlyDictionary<ItemSizeEnum, int> _CookTime = new Dictionary<ItemSizeEnum, int>()
        {
            { ItemSizeEnum.XSMALL, 500 },
            { ItemSizeEnum.SMALL, 1000 },
            { ItemSizeEnum.MEDIUM, 1500 },
            { ItemSizeEnum.BIG, 2000 },
            { ItemSizeEnum.XBIG, 2500 },
        };
        public static SaladArea Instance { get; set; }
        private SaladArea() : base(_CookTime) { }

        public static SaladArea GetInstance()
        {
            if (null == Instance)
                Instance = new SaladArea();

            return Instance;
        }
    }
}
