using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using customer_service.Models;
using customer_service.Data;

namespace customer_service
{

    /**
     * Class: LabelFactory
     * Purpose: Holds a singleton and can Get labels based on an IncidentTypeId
     * Author: Matt Kraatz
     * Methods:
     *     List<Label> getLabels(int id) - Gets all Labels that match an IncidentType
     */
    public class LabelFactory
    {
        // Make the factory a singleton to maintain state across all uses
        private static LabelFactory _instance;
        public static LabelFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LabelFactory();
                }
                return _instance;
            }
        }


        /**
         * Purpose: Gets Label records from database that match an IncidentTypeId
         * Return:
         *     List of applicable Labels
         */
        public List<Label> GetLabels(int id)
        {
            BangazonConnection conn = new BangazonConnection();
            List<Label> list = new List<Label>();

            // Execute the query to retrieve all customers
            conn.execute(@"SELECT 
                LabelId,
                Description
                FROM Label",
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        list.Add(new Label
                        {
                            LabelId = reader.GetInt32(0),
                            Description = reader[1].ToString()
                        });
                    }
                }
            );

            return list;
        }
    }
}
