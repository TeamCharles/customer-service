using customer_service.Data;
using customer_service.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace customer_service.Factories
{
    public class IncidentFactory
    {
        // Make the factory a singleton to maintain state across all uses
        private static IncidentFactory _instance;
        public static IncidentFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncidentFactory();
                }
                return _instance;
            }
        }

        // To track the currently active incident - selected by user
        private Incident _activeIncident = null;
        public Incident ActiveIncident
        {
            get
            {
                return _activeIncident;
            }
            set
            {
                _activeIncident = value;
            }
        }

        // Get a single incident
        public Incident get(int IncidentId)
        {
            BangazonConnection conn = new BangazonConnection();
            Incident i = null;

            conn.execute(@"select 
				IncidentId,
				IncidentTypeId,
				OrderId,
				EmployeeId,
				Resolution,
				DateResolved
				from Incident
				where IncidentId = " + IncidentId, (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    i = new Incident
                    {
                        IncidentId = reader.GetInt32(0),
                        IncidentTypeId = reader.GetInt32(1),
                        OrderId = reader.GetInt32(2),
                        EmployeeId = reader.GetInt32(3),
                        Resolution = reader[4].ToString(),
                        DateResolved = reader.GetDateTime(5)
                    };
                }
            });
            return i;
        }
        
        // Get all incidents
        public List<Incident> getAll()
        {
            BangazonConnection conn = new BangazonConnection();
            List<Incident> list = new List<Incident>();

            // Execute the query to retrieve all incidents
            conn.execute(@"select 
				IncidentId,
				IncidentTypeId,
				OrderId,
				EmployeeId,
				Resolution,
				DateResolved
				from Incident",
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        list.Add(new Incident
                        {
                            IncidentId = reader.GetInt32(0),
                            IncidentTypeId = reader.GetInt32(1),
                            OrderId = reader.GetInt32(2),
                            EmployeeId = reader.GetInt32(3),
                            Resolution = reader[4].ToString(),
                            DateResolved = reader.GetDateTime(5)
                        });
                    }
                }
            );
            return list;
        }
    }
}
