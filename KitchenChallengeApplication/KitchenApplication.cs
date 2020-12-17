using KitchenChallenge.Application.Factory;
using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenChallengeApplication
{
    public class KitchenApplication : IKitchenApplication
    {
        private readonly ILogger<KitchenApplication> _logger;
        private uint OrderNumber = 0;

        public KitchenApplication(ILogger<KitchenApplication> logger)
        {
            _logger = logger;
        }

        public async Task PrepareOrdersAsync(Queue<Order> ordersQueue)
        {
            _logger.LogInformation("Preparing order");

            while(ordersQueue.Count > 0)
            {
                var order = ordersQueue.Peek();
                order.Number = OrderNumber++;

                foreach (var item in order.Items)
                {
                    var kitchenArea = KitchenFactory.GetKicthenArea(item.Type);
                    //it must be async
                    await kitchenArea.PrepareItemAsync(item);
                }

                ordersQueue.Dequeue();
                _logger.LogInformation($"Order done!.\n{order}");
            }
        }
    }
}
