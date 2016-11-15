using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using customer_service;
using customer_service.Models;
using customer_service.Factories;

namespace customer_service_tests
{
    public class IncidentFactoryTests
    {
        [Fact]
        public void IncidentModelCreatesInstance()
        {
            IncidentType fakeIncidentType = new IncidentType();
            fakeIncidentType.IncidentTypeId = 999;
            fakeIncidentType.Label = "Fake";

            Order fakeOrder = new Order();
            fakeOrder.OrderId = 999;

            Incident incident = new Incident();
            incident.IncidentId = 9999;
            incident.DateCreated = DateTime.Now;
            incident.IncidentTypeId = 999;
            incident.IncidentType = fakeIncidentType;
            incident.OrderId = 999;
            incident.Order = fakeOrder;
            incident.Resolution = "Just Deal With it!";
            Assert.Equal(9999, incident.IncidentId);
            Assert.NotNull(incident.Order);
            Assert.NotNull(incident.IncidentType);
            Assert.Equal("Just Deal With it!", incident.Resolution);

        }

        [Fact]
        public void IncidentFactoryCanGetListOfIncidents()
        {
            IncidentFactory factory = new IncidentFactory();
            IEnumerable<Incident> list = factory.getAll();
            Assert.NotEmpty(list);

        }

    }
}
