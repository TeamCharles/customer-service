using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using customer_service;
using customer_service.Models;

namespace customer_service_tests
{
    public class IncidentFactoryTests
    {
        [Fact]
        public void CanInstantiateIncidentFactory()
        {
            var fact = new IncidentFactory();
            Assert.NotNull(fact);
        }

        [Fact]
        public void CanQueryAllIncidents()
        {
            var fact = new IncidentFactory();
            List<Incident> list = fact.getAll();
            Assert.IsType<List<Incident>>(list);
            Assert.NotNull(list[0].IncidentId);
            Assert.NotNull(list[0].EmployeeId);
            Assert.NotNull(list[0].OrderId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CanQuerySingleIncident(int id)
        {
            var fact = new IncidentFactory();
            Incident incident = fact.get(id);
            Assert.IsType<Incident>(incident);
            Assert.NotNull(incident.IncidentId);
            Assert.NotNull(incident.EmployeeId);
            Assert.NotNull(incident.OrderId);
        }

        [Theory]
        [InlineData("20160510")]
        public void CanParseDate(string date)
        {
            var fact = new IncidentFactory();
            DateTime? parsedDate = fact.ParseDate(date);
            Assert.Equal<DateTime?>(new DateTime(2016, 05, 10), parsedDate);
        }
    }
}
