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
     * Class: IncidentFactory
     * Purpose: Query the Incident table on the database to return a single Incident or all Incidents
     * Author: Matt Kraatz
     * Methods:
     *     get(int IncidentId) - Return a single Incident from the database, retrieved by IncidentId
     *     getAll() - Return a list of all Incidents from the database
     *     
     */
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

        /**
         * Purpose: Return a single Incident from the database, retrieved by IncidentId
         * Arguments:
         *     IncidentId - the Id of an Incident that is being requested
         * Return:
         *     An Incident matching the provided IncidentId retreived from the database
         */
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
                        DateResolved = ParseDate(reader[5].ToString())
                    };
                }
            });

            return i;
        }



        /**
         * Purpose: Return a list of all Incidents from the database
         * Arguments:
         *     void
         * Return:
         *     A list of Incidents currently in the database
         */
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
                            DateResolved = ParseDate(reader[5].ToString())
                        });
                    }
                }
            );
            return list;
        }

        /**
         * Purpose: Helper Method to convert a string date from format YYYYMMDD to a DateTime
         * Arguments:
         *     name - Description for name
         * Return:
         *     Description for return value
         */
        public DateTime? ParseDate(string date)
        {
            if (date != "")
            {
                var array = new int[3];
                array[0] = Int32.Parse(date.Substring(0, 4));
                array[1] = Int32.Parse(date.Substring(4, 2));
                array[2] = Int32.Parse(date.Substring(6, 2));
                return new DateTime(array[0], array[1], array[2]);
            } else
            {
                return null;
            }
        }
    }
}

