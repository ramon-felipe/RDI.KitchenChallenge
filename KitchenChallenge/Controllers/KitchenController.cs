using FluentValidation.Results;
using KitchenChallenge.API.Validations;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enums;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        [HttpPost("MakeOrder")]
        public async Task<ActionResult> MakeOrder([FromBody] IReadOnlyList<Order> ordersList)
        {
            var errors = ValidateOrders(ordersList);
            if (errors.Count > 0)
                return BadRequest(errors.Select(e => e));

            var ordersQueue = new ConcurrentQueue<Order>(ordersList);
            await _kitchenApplication.PrepareOrdersAsync(ordersQueue);

            return Ok("Orders prepared successfuly!");
        }

        private List<string> ValidateOrders(IEnumerable<Order> orders)
        {
            var errorsList = new List<string>();
            var validator = new OrderValidator();
            var result = new ValidationResult();

            foreach (var order in orders)
            {
                result = validator.Validate(order);
            }
            
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    var err = "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage;
                    errorsList.Add(err);
                    _logger.LogError(err);
                }
            }

            return errorsList;
        }
    }
}
