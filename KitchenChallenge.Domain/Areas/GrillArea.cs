using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class GrillArea : KitchenArea, IKitchenArea
    {
        private static IReadOnlyDictionary<ItemSizeEnum, int> _CookTime = new Dictionary<ItemSizeEnum, int>()
        {
            { ItemSizeEnum.XSMALL, 1500 },
            { ItemSizeEnum.SMALL, 2500 },
            { ItemSizeEnum.MEDIUM, 3500 },
            { ItemSizeEnum.BIG, 4500 },
            { ItemSizeEnum.XBIG, 5500 },
        };
        public static GrillArea Instance { get; set; }
        private GrillArea() : base(_CookTime) { }

        public static GrillArea GetInstance()
        {
            if (null == Instance)
                Instance = new GrillArea();

            return Instance;
        }
    }
}
