using Xunit;
using System.Collections.Generic;
using customer_service.Factories;
using customer_service.Models;
using customer_service.Data;

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
            EmployeeFactory employeeFactory = new EmployeeFactory();
            var employee = employeeFactory.get(id);

            Assert.NotNull(employee);
            Assert.True(employee.GetType() == typeof(Employee));
            Assert.True(employee.FirstName.Length > 0);
            Assert.True(employee.LastName.Length > 0);
            Assert.True(employee.DepartmentId.GetType() == typeof(int));
            Assert.True(employee.Administrator.GetType() == typeof(bool));
        }

        [Fact]
        public void CanGetAllEmployees()
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            var employeeList = employeeFactory.getAll();
            Assert.NotNull(employeeList);
            Assert.IsType<List<Employee>>(employeeList);

            foreach (var employee in employeeList)
            {
                Assert.NotNull(employee);
                Assert.True(employee.GetType() == typeof(Employee));
                Assert.True(employee.FirstName.Length > 0);
                Assert.True(employee.LastName.Length > 0);
                Assert.True(employee.DepartmentId.GetType() == typeof(int));
                Assert.True(employee.Administrator.GetType() == typeof(bool));
            }

        }
    }
}
