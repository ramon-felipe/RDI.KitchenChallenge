using KitchenChallenge.Domain.Order;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallengeApplication.Interfaces
{
    public interface IKitchenApplication
    {
        Task PrepareOrdersAsync(ConcurrentQueue<Order> orders);
    }
}
