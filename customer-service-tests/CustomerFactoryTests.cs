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
        public void CustomerFactoryCanBeCreated()
        {
            var customerFactory = new CustomerFactory();
            Assert.NotNull(customerFactory);
        }

        [Fact]
        public void CustomerFactorySetsActiveCustomer()
        {
            Customer customer = new Customer();
            customer.CustomerId = 9999;
            customer.DateCreated = DateTime.Now;
            customer.FirstName = "Garrett";
            customer.LastName = "Vangilder";

            CustomerFactory.Instance.ActiveCustomer = customer;

            Customer customer2 = new Customer();
            customer2.CustomerId = 9998;
            customer2.DateCreated = DateTime.Now;
            customer2.FirstName = "Matt";
            customer2.LastName = "Kraatz";

            CustomerFactory.Instance.ActiveCustomer = customer2;

            Assert.Equal("Matt", CustomerFactory.Instance.ActiveCustomer.FirstName);
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

        [Fact]
        public void CustomerFactoryWillGetMultipleCustomersFromDatabase()
        {
            CustomerFactory factory = new CustomerFactory();
            List<Customer> customers = factory.getAll();
            Assert.NotEmpty(customers);
            foreach (Customer customer in customers)
            {
                Assert.NotNull(customer.CustomerId);
                Assert.NotNull(customer.FirstName);
                Assert.NotNull(customer.LastName);
            }
        }
    }
}
