using KitchenChallenge.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas.Interfaces
{
    public interface IKitchenArea
    {
        Task PrepareItemAsync(Item item);
    }
}
