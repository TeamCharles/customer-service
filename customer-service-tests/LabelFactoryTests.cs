using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using customer_service;
using customer_service.Models;

namespace customer_service_tests
{
    public class LabelFactoryTests
    {
        [Fact]
        public void CanInstantiateEmployeeFactory()
        {
            var instance = LabelFactory.Instance;
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CanGetLabelsByIncidentTypeId(int id)
        {
            var fact = new LabelFactory();
            List<Label> label = fact.GetLabels(id);
            Assert.NotNull(label);
            Assert.NotNull(label[0].LabelId);
            Assert.NotNull(label[0].Description);
        }
    }
}
