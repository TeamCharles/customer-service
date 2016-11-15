using Xunit;
using System.Collections.Generic;
using customer_service;
using customer_service.Models;
using customer_service.Data;

namespace customer_service_tests
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void CanInstantiateEmployeeFactory()
        {
            var instance = EmployeeFactory.Instance;
            Assert.NotNull(instance);
        }

        [Fact]
        public void EmployeeFactoryIsSingleton()
        {
            var instance1 = EmployeeFactory.Instance;
            var instance2 = EmployeeFactory.Instance;
            Assert.Equal(instance1, instance2);
        }

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

        [Fact]
        public void CanGetEmployeeByFullName()
        {
            string fullName = "Matt Hamil";
            EmployeeFactory employeeFactory = new EmployeeFactory();
            var shouldBeMatt = employeeFactory.getEmployeeByFullName(fullName);

            Assert.NotNull(shouldBeMatt);
            Assert.True(shouldBeMatt.GetType() == typeof(Employee));
            Assert.True(shouldBeMatt.FirstName == "Matt");
            Assert.True(shouldBeMatt.LastName == "Hamil");
            Assert.True(shouldBeMatt.DepartmentId.GetType() == typeof(int));
            Assert.True(shouldBeMatt.Administrator.GetType() == typeof(bool));
        }
    }
}
