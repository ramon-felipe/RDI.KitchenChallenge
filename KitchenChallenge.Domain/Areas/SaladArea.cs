using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class SaladArea : KitchenArea, IKitchenArea
    {
        public static SaladArea Instance { get; set; }
        private SaladArea() { }

        public static SaladArea GetInstance()
        {
            if (null == Instance)
                Instance = new SaladArea();

            return Instance;
        }
    }
}
