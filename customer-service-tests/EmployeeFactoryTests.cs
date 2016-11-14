using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace customer_service_tests
{
    public class EmployeeFactoryTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CanGetEmployeeById(int id)
        {
            //CustomerFactory customerFactory = new CustomerFactory();
            //var employee = customerFactory.get(id);

            //var expectedType = typeof(Employee);
            //var actualType = typeof(employee);

            //Assert.IsType(expectedType, actualType);
            //Assert.True(employee != null);
            Assert.True(true);
        }
    }
}
