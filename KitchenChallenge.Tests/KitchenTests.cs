using KitchenChallenge.Controllers;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Enums;
using KitchenChallenge.Domain.Order;
using KitchenChallengeApplication;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace KitchenChallenge.Tests
{
    public class KitchenTests
    {
        private readonly Mock<ILogger<KitchenApplication>> loggerMock;
        private readonly Mock<ILogger<KitchenController>> loggerControllerMock;
        private readonly KitchenApplication kitchenApplication;
        private readonly KitchenController kitchenController;

        public KitchenTests()
        {
            loggerMock = new Mock<ILogger<KitchenApplication>>();
            loggerControllerMock = new Mock<ILogger<KitchenController>>();
            ILogger<KitchenApplication> loggerApplication = loggerMock.Object;
            ILogger<KitchenController> loggerController = loggerControllerMock.Object;
            kitchenApplication = new KitchenApplication(loggerApplication);
            kitchenController = new KitchenController(loggerController, kitchenApplication);
        }

        [Fact(DisplayName = "Order ONE item with cooktime NOT set")]
        public async void OrderOneItemWithoutCookTime_ShouldReturnBadRequest()
        {
            //Arrange
            var Items = new List<Item>()
            {
                new Item{ CookTime = 0, Description = "item 1", Price = 2.2M, Size = ItemSizeEnum.BIG, Type = ItemType.DESERT}
            };

            var order = new Order { Items = Items };

            IReadOnlyList<Order> orderList = new List<Order>()
            {
                { order }
            };

            //Act
            var result = await kitchenController.MakeOrder(orderList);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be((int)(HttpStatusCode.BadRequest));
        }
        
        [Fact(DisplayName = "Order ONE Item with Price Not set")]
        public async void OrderOneItemWithoutPrice_ShouldReturnBadRequest()
        {
            //Arrange
            var Items = new List<Item>()
            {
                new Item{ CookTime = 2000, Description = "item 1", Price = 0M, Size = ItemSizeEnum.BIG, Type = ItemType.DESERT}
            };

            var order = new Order { Items = Items };

            IReadOnlyList<Order> orderList = new List<Order>()
            {
                { order }
            };

            //Act
            var result = await kitchenController.MakeOrder(orderList);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be((int)(HttpStatusCode.BadRequest));
        }
        
        [Fact(DisplayName = "Order ONE Item with CookTime and Price Not set")]
        public async void OrderOneItemWithoutCookTimeAndPrice_ShouldReturnBadRequest()
        {
            //Arrange
            var Items = new List<Item>()
            {
                new Item{ CookTime = 0, Description = "item 1", Price = 0M, Size = ItemSizeEnum.BIG, Type = ItemType.DESERT}
            };

            var order = new Order { Items = Items };

            IReadOnlyList<Order> orderList = new List<Order>()
            {
                { order }
            };

            //Act
            var result = await kitchenController.MakeOrder(orderList);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be((int)(HttpStatusCode.BadRequest))
            ;
        }
                
        [Fact(DisplayName = "Order ONE Item successfully")]
        public async void OrderOneItemCorrectly_ShouldReturnOk()
        {
            //Arrange
            var Items = new List<Item>()
            {
                new Item{ CookTime = 1000, Description = "item 1", Price = 5.2M, Size = ItemSizeEnum.BIG, Type = ItemType.DESERT}
            };

            var order = new Order { Items = Items };

            IReadOnlyList<Order> orderList = new List<Order>()
            {
                { order }
            };

            //Act
            var result = await kitchenController.MakeOrder(orderList);

            //Assert
            result.Should().BeOfType<OkObjectResult>()
                    .Which.StatusCode.Should().Be((int)(HttpStatusCode.OK))
                ;
        }

        [Theory(DisplayName = "Order MANY Items successfully")]
        [MemberData(nameof(ItemData))]
        public async void OrderManyItemsCorrectly_ShouldReturnOk(List<Item> items)
        {
            //Arrange
            var order = new Order { Items = items };

            IReadOnlyList<Order> orderList = new List<Order>()
            {
                { order }
            };

            var orders = new ConcurrentQueue<Order>(orderList);

            //Act
            var result = await kitchenController.MakeOrder(orderList);

            //Assert
            result.Should().BeOfType<OkObjectResult>()
                    .Which.StatusCode.Should().Be((int)(HttpStatusCode.OK))
                ;
        }

        public static IEnumerable<object[]> ItemData() 
        {
            yield return new object[] { new List<Item>() { new Item { CookTime = 1000, Description = "item 1", Price = 2.2M, Size = ItemSizeEnum.XSMALL, Type = ItemType.DESERT } } };
            yield return new object[] { new List<Item>() { new Item { CookTime = 2000, Description = "item 2", Price = 1.2M, Size = ItemSizeEnum.SMALL, Type = ItemType.DRINK } } };
            yield return new object[] { new List<Item>() { new Item { CookTime = 2000, Description = "item 3", Price = 2.9M, Size = ItemSizeEnum.MEDIUM, Type = ItemType.FRIES } } };
            yield return new object[] { new List<Item>() { new Item { CookTime = 2000, Description = "item 4", Price = 3.7M, Size = ItemSizeEnum.BIG, Type = ItemType.SALAD } } };
            yield return new object[] { new List<Item>() { new Item { CookTime = 3000, Description = "item 5", Price = 0.2M, Size = ItemSizeEnum.XBIG, Type = ItemType.GRILL } } };
        }
    }
}
