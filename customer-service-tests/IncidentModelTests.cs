using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using customer_service;
using customer_service.Models;

namespace customer_service_tests
{
    public class IncidentModelTests
    {
        [Fact]
        public void CanSaveNewIncidentToDB()
        {
            var incident = new Incident();
            incident.EmployeeId = 1;
            incident.IncidentTypeId = 1;
            incident.OrderId = 1;
            incident.save();

            var fact = new IncidentFactory();
            // Get All Incidents, Compare Last Incident in List to Saved Incident

        }

        [Fact]
        public void CanUpdateIncidentInDB()
        {
            var incident = new Incident();
            var fact = new IncidentFactory();
            // Get All Incidents, Save Last Incident in List

            incident.Resolution = "Test Resolution";
            incident.DateResolved = DateTime.Today;
            incident.update();

            // Get All Incidents, Compare Last Incident in List to Saved Incident
        }

        [Fact]
        public void CleanUpIncidentInDB()
        {
            // Remove Last Incident from Database
        }
    }
}
