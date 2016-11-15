using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_service;
using customer_service.Models;
using customer_service.Data;
using customer_service.Factories;
using Xunit;

namespace customer_service_tests
{
    public class OrderFactoryTests
    {
        [Fact]

        public void CanInstantiateOrderFactory()
        {
            var instance = OrderFactory.Instance;
            Assert.NotNull(instance);

        }

        [Fact]

        public void OrderFactoryIsSingleton()
        {
            var fact1 = OrderFactory.Instance;
            var fact2 = OrderFactory.Instance;
            Assert.Equal(fact1, fact2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void OrderFactoryGetIncidentsByCustomerId(int customerId)
        {
            OrderFactory orderFactory = new OrderFactory();
            var orderList = orderFactory.getAllOrdersFromCustomer(customerId);

            Assert.NotNull(orderList);

            Assert.True(orderList.GetType() == typeof(List<Order>));

            foreach (var order in orderList)
            {
                Assert.NotNull(order);
                Assert.True(order.OrderId.GetType() == typeof(int));
                Assert.True(order.Date.GetType() == typeof(DateTime));
                Assert.True(order.DateCreated.GetType() == typeof(DateTime));
            }
        }
    }
}
