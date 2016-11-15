using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Actions
{
    public class CreateIncidentAction
    {
        [Fact]
        public void CanSaveNewIncidentToDatabase()
        {
            var incidentFactory = new IncidentFactory();
            List<Incident> allIncidents = incidentFactory.getAll();
            int newIncidentId = allIncidents[allIncidents.Count].IncidentId;
            Assert.NotNull(instance);

            Incident BadIncident = new Incident();
        }
    }
}
