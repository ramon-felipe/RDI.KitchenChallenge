using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class GrillArea : KitchenArea, IKitchenArea
    {
        public static GrillArea Instance { get; set; }
        private GrillArea() { }

        public static GrillArea GetInstance()
        {
            if (null == Instance)
                Instance = new GrillArea();

            return Instance;
        }
    }
}
