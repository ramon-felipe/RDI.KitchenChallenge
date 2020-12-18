using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enum;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KitchenChallenge.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KitchenController : ControllerBase
    {
        private readonly IKitchenApplication _kitchenApplication;
        private readonly ILogger<KitchenController> _logger;


        public KitchenController(ILogger<KitchenController> logger, IKitchenApplication kitchenApplication)
        {
            _logger = logger;
            _kitchenApplication = kitchenApplication;
        }

        [HttpGet("teste")]
        public async Task Get()
        {
            try
            {
                var ordersQueue = new Queue<Order>();
            
                Order order1 = new Order()
                {
                    Items = new List<Item>()
                    {
                       new Item(){ Type= ItemType.DESERT, Description = "Sundae" },
                       new Item(){ Type= ItemType.FRIES, Description = "Fries", Size = ItemSizeEnum.SMALL }
                    },
                };
            
                Order order2 = new Order()
                {
                    Items = new List<Item>()
                    {
                       new Item(){ Type= ItemType.SALAD, Description = "Ceaser Salad" },
                       new Item(){ Type= ItemType.FRIES, Description = "Fries", Size = ItemSizeEnum.SMALL }
                    },
                };
            
                Order order3 = new Order()
                {
                    Items = new List<Item>()
                    {
                       new Item(){ Type= ItemType.FRIES, Description = "Fries", Size = ItemSizeEnum.BIG },
                       new Item(){ Type= ItemType.FRIES, Description = "Fries", Size = ItemSizeEnum.SMALL }
                    },
                };

                ordersQueue.Enqueue(order1);
                ordersQueue.Enqueue(order2);
                ordersQueue.Enqueue(order3);

                await _kitchenApplication.PrepareOrdersAsync(ordersQueue);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
