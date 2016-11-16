using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using customer_service.Data;
using Microsoft.Data.Sqlite;
using customer_service.Models;

namespace customer_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BangazonConnection conn = new BangazonConnection();
            Customer customer = new Customer();
            Incident incident = new Incident();

            conn.execute(@"SELECT * FROM Customer WHERE CustomerId = 3",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        customer.CustomerId = reader.GetInt32(0);
                        customer.FirstName = reader[1].ToString();
                        customer.LastName = reader[2].ToString();
                        customer.DateCreated = reader.GetDateTime(3);
                    }

                    CustomerFactory.Instance.ActiveCustomer = customer;
                });
            conn.execute($@"SELECT 
                            I.IncidentId,
                            I.IncidentTypeId,
                            I.OrderId,
                            I.EmployeeId,
                            I.Resolution,
                            I.DateResolved
                            FROM Incident AS I
                            JOIN ""Order"" AS O
	                            ON O.OrderId = I.OrderId
                            JOIN Customer AS C
	                            ON O.CustomerId = C.CustomerId
                            WHERE C.CustomerId = {customer.CustomerId}",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        incident.IncidentId = reader.GetInt32(0);
                        incident.IncidentTypeId = reader.GetInt32(1);
                        incident.OrderId = reader.GetInt32(2);
                        incident.EmployeeId = reader.GetInt32(3);
                        incident.Resolution = reader[4].ToString();
                        incident.DateResolved = ParseDate(reader[5].ToString());
                    }

                    IncidentFactory.Instance.ActiveIncident = incident;
                });

            ShowSingleIncidentAction.ReadInput();
        }

        public static DateTime? ParseDate(string date)
        {
            if (date != "")
            {
                var array = new int[3];
                array[0] = Int32.Parse(date.Substring(0, 4));
                array[1] = Int32.Parse(date.Substring(4, 2));
                array[2] = Int32.Parse(date.Substring(6, 2));
                return new DateTime(array[0], array[1], array[2]);
            }
            else
            {
                return null;
            }
        }
    }
}
