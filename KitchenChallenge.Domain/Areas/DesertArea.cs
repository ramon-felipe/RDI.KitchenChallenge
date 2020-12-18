using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class DesertArea : KitchenArea, IKitchenArea
    {
        private static IReadOnlyDictionary<ItemSizeEnum, int> _CookTime = new Dictionary<ItemSizeEnum, int>()
        {
            { ItemSizeEnum.XSMALL, 500 },
            { ItemSizeEnum.SMALL, 1000 },
            { ItemSizeEnum.MEDIUM, 1500 },
            { ItemSizeEnum.BIG, 2000 },
            { ItemSizeEnum.XBIG, 2500 },
        };
        public static DesertArea Instance { get; set; }
        private DesertArea() : base(_CookTime) { }

        public static DesertArea GetInstance()
        {
            if (null == Instance)
                Instance = new DesertArea();

            return Instance;
        }
    }
}
