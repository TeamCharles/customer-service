using Xunit;
using customer_service.Factories;
using customer_service.Models;

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
            EmployeeFactory customerFactory = new EmployeeFactory();
            var employee = employeeFactory.get(id);

            var expectedType = typeof(Employee);
            var actualType = typeof(employee);

            Assert.IsType(expectedType, actualType);
            Assert.NotNull(employee);
            Assert.NotNull(employee.DateCreated);
            Assert.True(employee.FirstName.Length > 0);
            Assert.True(employee.LastName.Length > 0);
            Assert.IsType(typeof(employee.DepartmentId), typeof(int));
            Assert.IsType(typeof(employee.Administrator), typeof(bool));
        }
    }
}
