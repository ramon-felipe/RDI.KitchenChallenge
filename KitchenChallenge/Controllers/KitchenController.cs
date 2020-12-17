using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Dishes;
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
        public void Get()
        {
            Order order = new Order()
            {
                Number = 1,
                Items = new List<Dish>()
                {

                },
            };

            _kitchenApplication.PrepareDish(order);

            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}
