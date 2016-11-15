using System;
using System.Collections.Generic;
using System.Linq;
using customer_service.Models;
using System.Threading.Tasks;
using Xunit;
using customer_service;

namespace customer_service_tests
{
    public class CustomerFactoryTests
    {
        [Fact]
        public void CustomerModelCreatesNewCustomer()
        {
            Customer customer = new Customer();
            customer.CustomerId = 9999;
            customer.DateCreated = DateTime.Now;
            customer.FirstName = "Garrett";
            customer.LastName = "Vangilder";
            Assert.Equal(9999, customer.CustomerId);
            Assert.NotNull(customer.DateCreated);
            Assert.Equal("Garrett", customer.FirstName);
            Assert.Equal("Vangilder", customer.LastName);
        }

        [Fact]
        public void CustomerModelSetsActiveCustomer()
        {
            var customer = CustomerFactory.Instance;
            Assert.NotNull(customer);

        }

        [Fact]
        public void CustomerFactoryWillGetSingleCustomerFromDatabase()
        {
            CustomerFactory factory = new CustomerFactory();
            Customer customer = factory.get(1);
            Assert.Equal("Steve", customer.FirstName);
            Assert.Equal("Brownlee", customer.LastName);
            Assert.Equal(1, customer.CustomerId);
        }
    }
}
