using System;
using customer_service.Data;
using Microsoft.Data.Sqlite;
using customer_service.Models;
using customer_service.Actions;

namespace customer_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Used to run Actions/ShowSingleIncidentActions.cs
            // Will be removed before merge
            BangazonConnection conn = new BangazonConnection();
            Employee employee = new Employee();

            conn.execute(@"SELECT * FROM Employee WHERE EmployeeId = 1",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        employee.EmployeeId = reader.GetInt32(0);
                        employee.FirstName = reader[1].ToString();
                        employee.LastName = reader[2].ToString();
                        employee.DepartmentId = reader.GetInt32(3);
                        employee.Administrator = (reader.GetInt32(4) == 0 ? false : true);
                        employee.DateCreated= reader.GetDateTime(5);
                    }

                    EmployeeFactory.Instance.ActiveEmployee = employee;
                });

            ListIncidentsAction.ReadInput();
        }
    }
}
