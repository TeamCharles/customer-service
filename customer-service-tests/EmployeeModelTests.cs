using Xunit;
using System.Collections.Generic;
using customer_service;
using customer_service.Models;
using customer_service.Data;

namespace customer_service_tests
{
    public class EmployeeModelTests
    {
        [Fact]
        public void CanSaveNewEmployeeToDatabase()
        {
            var employeeFactory = new EmployeeFactory();
            List<Employee> allEmployees = employeeFactory.getAll();
            int newEmployeeId = allEmployees[allEmployees.Count - 1].EmployeeId;

            Employee Jeb = new Employee()
            {
                FirstName = "Jeb",
                LastName = "Bush",
                DepartmentId = 1,
                Administrator = false
            };

            Jeb.save();

            var shouldBeJeb = employeeFactory.get(newEmployeeId);

            Assert.NotNull(shouldBeJeb);
            Assert.True(newEmployeeId == shouldBeJeb.EmployeeId);
            Assert.True(Jeb.FirstName == shouldBeJeb.FirstName);
            Assert.True(Jeb.LastName == shouldBeJeb.LastName);
            Assert.True(Jeb.DepartmentId == shouldBeJeb.DepartmentId);
            Assert.True(Jeb.Administrator == shouldBeJeb.Administrator);
        }
    }
}