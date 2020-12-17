using KitchenChallenge.Domain.Areas;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication.Interfaces;
using Microsoft.Extensions.Logging;
using System;
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

        public async Task PrepareDish(Order order)
        {
            _logger.LogInformation("Preparing order");

            var desertArea = DesertArea.GetInstance();
            await desertArea.PrepareDish();
        }
    }
}
