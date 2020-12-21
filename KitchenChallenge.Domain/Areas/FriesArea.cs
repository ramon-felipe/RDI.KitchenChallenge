using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class FriesArea : KitchenArea, IKitchenArea
    {
        public static FriesArea Instance { get; set; }
        private FriesArea() { }

        public static FriesArea GetInstance()
        {
            if (null == Instance)
                Instance = new FriesArea();

            return Instance;
        }
    }
}
