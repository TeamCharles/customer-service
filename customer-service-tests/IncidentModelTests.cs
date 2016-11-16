using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using customer_service;
using customer_service.Models;
using customer_service.Data;

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
            List<Incident> list = fact.getAll();
            Incident last = list.Last();

            Assert.Equal(incident.EmployeeId, last.EmployeeId);
            Assert.Equal(incident.IncidentTypeId, last.IncidentTypeId);
            Assert.Equal(incident.OrderId, last.OrderId);
        }

        [Fact]
        public void CanUpdateIncidentInDB()
        {
            var fact = new IncidentFactory();
            Incident last = fact.getAll().Last();

            last.Resolution = "Test Resolution";
            last.DateResolved = DateTime.Today;
            last.update();

            Incident updated = fact.get(last.IncidentId);
            Assert.Equal(updated.Resolution, last.Resolution);
            Assert.Equal(updated.DateResolved, last.DateResolved);
            // Remove Last Incident from Database
            if (last.IncidentId == updated.IncidentId)
            {
                var conn = new BangazonConnection();
                conn.insert($"DELETE FROM Incident WHERE IncidentId = {updated.IncidentId}");
            }
        }
    }
}
