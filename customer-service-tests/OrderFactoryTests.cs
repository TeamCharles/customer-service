using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_service;
using customer_service.Models;
using customer_service.Data;
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

        [Theory]
         [InlineData(20160510)]
         public void CanParseDate(string date)
         {
             var order = new OrderFactory();
             DateTime? parsedDate = order.ParseDate(date);
             Assert.Equal<DateTime?>(new DateTime(2016, 05, 10), parsedDate);
         }

        [Theory]

        [InlineData(3)]
        public void CanGetOrderById(int id)
        {
            var order = new OrderFactory();
            var newOrder = order.get(id);
            Assert.True(newOrder.GetType() == typeof(Order));
        }
    }
}
