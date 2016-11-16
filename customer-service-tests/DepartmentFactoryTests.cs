using Xunit;
using System.Collections.Generic;
using customer_service;
using customer_service.Models;
using customer_service.Data;

namespace customer_service_tests
{
    public class DepartmentFactoryTests
    {
        [Fact]
        public void CanInstantiateDepartmentFactory()
        {
            var instance = DepartmentFactory.Instance;
            Assert.NotNull(instance);
        }

        [Fact]
        public void DepartmentFactoryIsSingleton()
        {
            var instance1 = EmployeeFactory.Instance;
            var instance2 = EmployeeFactory.Instance;
            Assert.Equal(instance1, instance2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void CanGetDepartmentById(int id)
        {
            DepartmentFactory departmentFactory = new DepartmentFactory();
            var department = departmentFactory.get(id);

            Assert.NotNull(department);
            Assert.True(department.GetType() == typeof(Department));
            Assert.True(department.DepartmentId.GetType() == typeof(int));
            Assert.NotNull(department.Label);
            Assert.NotNull(department.DepartmentId);
        }

        [Fact]
        public void CanGetAllDepartments()
        {
            DepartmentFactory departmentFactory = new DepartmentFactory();
            var departmentList = departmentFactory.getAll();
            Assert.NotNull(departmentList);
            Assert.IsType<List<Department>>(departmentList);

            foreach (var department in departmentList)
            {
                Assert.NotNull(department);
                Assert.True(department.GetType() == typeof(Department));
                Assert.True(department.DepartmentId.GetType() == typeof(int));
                Assert.NotNull(department.Label);
                Assert.NotNull(department.DepartmentId);
            }

        }
    }
}
