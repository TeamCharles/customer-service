using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_service.Data;
using customer_service.Models;
using Microsoft.Data.Sqlite;

namespace customer_service
{

    /**
     * Class: IncidentTypeFactory
     * Purpose: Provide all interactions with the IncidentType table on the database
     * Author: Matt Kraatz
     * Methods:
     *     List<IncidentType> getAll() - Retrieves all Incident Types from the database
     */
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


        /**
         * Purpose: Retrieve all Incident Types from the database
         * Arguments:
         *     void
         * Return:
         *     A list of all Incident Types with an IncidentTypeId and Label
         */
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
