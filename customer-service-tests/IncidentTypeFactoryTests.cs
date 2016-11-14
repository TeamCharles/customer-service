using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using customer_service;
using customer_service.Models;

namespace customer_service_tests
{
    public class IncidentTypeFactoryTests
    {
        [Fact]
        public void CanInstantiateIncidentTypeFactory()
        {
            var fact = IncidentTypeFactory.Instance;
            Assert.NotNull(fact);
        }

        [Fact]
        public void IncidentTypeFactoryIsSingleton()
        {
            var fact1 = IncidentTypeFactory.Instance;
            var fact2 = IncidentTypeFactory.Instance;
            Assert.Equal(fact1, fact2);
        }

        [Fact]
        public void CanGetAllIncidentTypes()
        {
            var types = IncidentTypeFactory.Instance.getAll();
            Assert.IsType<List<IncidentType>>(types);
            Assert.NotNull(types[0].IncidentTypeId);
            Assert.NotNull(types[0].Label);
        }
    }
}
