using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Areas.Interfaces;
using KitchenChallenge.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Application.Factory
{
    public class KitchenFactory
    {
        public static IKitchenArea GetKitchenArea(ItemType dishType)
        {
            if (dishType.Equals(ItemType.DESERT))
                return DesertArea.GetInstance();
            else if (dishType.Equals(ItemType.DRINK))
                return DrinkArea.GetInstance();
            else if (dishType.Equals(ItemType.FRIES))
                return FriesArea.GetInstance();
            else if (dishType.Equals(ItemType.GRILL))
                return GrillArea.GetInstance();
            else if (dishType.Equals(ItemType.SALAD))
                return SaladArea.GetInstance();

            throw new NotImplementedException($"We do not have an area to prepare this kind of food.");
        }
    }
}
