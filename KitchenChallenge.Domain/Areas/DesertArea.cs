using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enums;
using System.Collections.Generic;

namespace KitchenChallenge.Domain.Areas
{
    public class DesertArea : KitchenArea, IKitchenArea
    {        
        public static DesertArea Instance { get; set; }
        private DesertArea() { }

        public static DesertArea GetInstance()
        {
            if (null == Instance)
                Instance = new DesertArea();

            return Instance;
        }
    }
}
