using Xunit;
using System.Collections.Generic;
using customer_service;
using customer_service.Models;
using customer_service.Data;
using System.Linq;

namespace customer_service_tests
{
    public class EmployeeModelTests
    {
        [Fact]
        public void CanSaveNewEmployeeToDatabase()
        {
            var employeeFactory = new EmployeeFactory();
            int lastPK = employeeFactory.getAll().Last().EmployeeId;

            Employee Jeb = new Employee()
            {
                FirstName = "Jeb",
                LastName = "Bush",
                DepartmentId = 1,
                Administrator = false
            };

            Jeb.save();

            Employee shouldBeJeb = employeeFactory.getAll().Last();

            Assert.NotNull(shouldBeJeb);
            Assert.NotNull(shouldBeJeb.EmployeeId);
            Assert.True(shouldBeJeb.EmployeeId > lastPK);
            Assert.True(Jeb.FirstName == shouldBeJeb.FirstName);
            Assert.True(Jeb.LastName == shouldBeJeb.LastName);
            Assert.True(Jeb.DepartmentId == shouldBeJeb.DepartmentId);
            Assert.True(Jeb.Administrator == shouldBeJeb.Administrator);

            var conn = new BangazonConnection();
            conn.insert($"DELETE FROM Employee WHERE EmployeeId = {shouldBeJeb.EmployeeId}");
        }
    }
}