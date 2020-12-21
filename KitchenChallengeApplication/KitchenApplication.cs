using KitchenChallenge.Application.Factory;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenChallengeApplication
{
    public class KitchenApplication : IKitchenApplication
    {
        private readonly ILogger<KitchenApplication> _logger;

        public KitchenApplication(ILogger<KitchenApplication> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Prepares orders asynchronously
        /// </summary>
        /// <param name="ordersQueue">A queue containing orders</param>
        /// <returns></returns>
        public async Task PrepareOrdersAsync(ConcurrentQueue<Order> ordersQueue)
        {
            var exceptions = new List<Exception>();

            try
            {
                _logger.LogInformation("Preparing orders");
                Stopwatch regularSW = new Stopwatch();
                regularSW.Start();

                var orderTaskList = new List<Task>();
                void action()
                {
                    while (ordersQueue.TryDequeue(out Order o))
                        orderTaskList.Add(PrepareOrderItemsAsync(o));
                }

                await Task.Run(action);
                await Task.WhenAll(orderTaskList);

                regularSW.Stop();
                _logger.LogInformation($"...:::ORDERS READY:::... TOTAL TIME ELAPSED: {regularSW.ElapsedMilliseconds} (ms)...");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "!!!Error ocurred when preparing an order!!!");
                exceptions.Add(e);
            }

            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }

        /// <summary>
        /// It prepares orders items asyncronously and finishes when all of the order items is ready
        /// </summary>
        /// <param name="order">The order with items that is going to be prepared</param>
        /// <returns></returns>
        private async Task PrepareOrderItemsAsync(Order order)
        {
            Stopwatch regularSW = new Stopwatch();
            regularSW.Start();
            List<Task> orderItemsPreparation = new List<Task>();
            
            foreach (var item in order.Items)
            {
                var kitchenArea = KitchenFactory.GetKitchenArea(item.Type);

                orderItemsPreparation.Add(kitchenArea.PrepareItemAsync(item));
            }

            await Task.WhenAll(orderItemsPreparation);
            regularSW.Stop();
            _logger.LogInformation($"...:::ORDER DONE (Total price: ${order.Amount}) :::...\n{order}\nOrder time elapsed: {regularSW.ElapsedMilliseconds} (ms)");
        }
    }
}
