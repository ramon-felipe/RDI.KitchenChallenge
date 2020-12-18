using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enums;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost("teste")]
        public async Task Get([FromBody] IReadOnlyList<Order> ordersList)
        {
            try
            {
                var ordersQueue = new Queue<Order>(ordersList);       

                await _kitchenApplication.PrepareOrdersAsync(ordersQueue);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
