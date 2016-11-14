using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_service.Data;
using customer_service.Models;
using Microsoft.Data.Sqlite;

namespace customer_service
{
    public class IncidentTypeFactory
    {
        // Make the factory a singleton to maintain state across all uses
        private static IncidentTypeFactory _instance;
        public static IncidentTypeFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncidentTypeFactory();
                }
                return _instance;
            }
        }

        // Get all customers
        public List<IncidentType> getAll()
        {
            BangazonConnection conn = new BangazonConnection();
            List<IncidentType> list = new List<IncidentType>();

            // Execute the query to retrieve all customers
            conn.execute(@"select 
				IncidentTypeId,
				Label 
				from IncidentType",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        list.Add(new IncidentType
                        {
                            IncidentTypeId = reader.GetInt32(0),
                            Label = reader[1].ToString()
                        });
                    }
                }
            );

            return list;
        }
    }
}
