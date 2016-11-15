using customer_service.Factories;
using customer_service.Models;
using Xunit;

namespace customer_service_tests
{
    public class IncidentFactoryTests
    {
        [Fact]
        public void CanSetSingletonOfIncident()
        {
            Incident incident = new Incident();
            IncidentFactory.Instance.ActiveIncident = incident;
            var activeIncident = IncidentFactory.Instance.ActiveIncident;

            Assert.NotNull(activeIncident);
        }

        [Fact]
        public void CanGetAllIncidents()
        {

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CanGetASingleIncident(int id)
        {

        }
    }
}
