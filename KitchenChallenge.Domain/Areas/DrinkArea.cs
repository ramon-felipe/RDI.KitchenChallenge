using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class DrinkArea : KitchenArea, IKitchenArea
    {
        public static DrinkArea Instance { get; set; }
        private DrinkArea() { }

        public static DrinkArea GetInstance()
        {
            if (null == Instance)
                Instance = new DrinkArea();

            return Instance;
        }
    }
}
