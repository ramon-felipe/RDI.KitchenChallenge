using KitchenChallenge.Application.Factory;
using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenChallengeApplication
{
    public class KitchenApplication : IKitchenApplication
    {
        private readonly ILogger<KitchenApplication> _logger;
        private uint OrderNumber = 1;

        public KitchenApplication(ILogger<KitchenApplication> logger)
        {
            _logger = logger;
        }

        public async Task PrepareOrdersAsync(Queue<Order> ordersQueue)
        {
            _logger.LogInformation("Preparing order");
            var exceptions = new List<Exception>();
            List<Task> orderItemsPreparation = new List<Task>();

            while (ordersQueue.Count > 0)
            {
                var order = ordersQueue.Peek();
                order.Number = OrderNumber++;
                
                try
                {
                    foreach (var item in order.Items)
                    {
                        var kitchenArea = KitchenFactory.GetKitchenArea(item.Type);

                        orderItemsPreparation.Add(kitchenArea.PrepareItemAsync(item));
                    }

                    await Task.WhenAll(orderItemsPreparation);

                    _logger.LogInformation($"Order ({order.Number}) done!.\n{order}");
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"An error occurred with order {order.Number}.\n{order}.\n({e.Message})");
                    exceptions.Add(e);
                }

                ordersQueue.Dequeue();
            }

            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }
    }
}
