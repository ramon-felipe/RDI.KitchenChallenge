using KitchenChallenge.Domain.Areas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KitchenChallenge.Domain.Areas
{
    public class DesertArea : IKitchenArea
    {
        public static DesertArea Instance { get; set; }
        public int OrderNumber { get; private set; }

        private DesertArea() {}

        public static DesertArea GetInstance()
        {
            if (null == Instance)
                Instance = new DesertArea();

            return Instance;
        }

        public async Task PrepareDish()
        {
            Console.WriteLine("Preparing desert...");
            await Task.Delay(1000);
            OrderNumber++;

            Console.WriteLine("Desert done!");
        }
    }
}
