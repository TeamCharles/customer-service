using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using customer_service.Models;
using customer_service.Data;

namespace customer_service.Factories
{
    public class EmployeeFactory
    {
        // Make the factory a singleton to maintain state across all uses
        private static EmployeeFactory _instance;
        public static EmployeeFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeFactory();
                }
                return _instance;
            }
        }

        // To track the currently active employee - selected by user
        private Employee _activeEmployee = null;
        public Employee ActiveEmployee
        {
            get
            {
                return _activeEmployee;
            }
            set
            {
                _activeEmployee = value;
            }
        }

        // Get a single employee
        public Employee get(int EmployeeId)
        {
            BangazonConnection conn = new BangazonConnection();
            Employee e = null;

            conn.execute(@"SELECT 
                EmployeeId,
                FirstName, 
                LastName, 
                DepartmentId,
                Administrator
                FROM Employee
                WHERE EmployeeId = " + EmployeeId, (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    e = new Employee
                    {
                        EmployeeId = reader.GetInt32(0),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        DepartmentId = reader.GetInt32(3),
                        Administrator = Convert.ToBoolean(reader.GetInt32(4))
                    };
                }
            });


            return e;
        }

        // Get all employees
        public List<Employee> getAll()
        {
            BangazonConnection conn = new BangazonConnection();
            List<Employee> list = new List<Employee>();

            // Execute the query to retrieve all customers
            conn.execute(@"SELECT 
                EmployeeId,
                FirstName, 
                LastName, 
                DepartmentId,
                Administrator
                FROM Employee",
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            EmployeeId = reader.GetInt32(0),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            DepartmentId = reader.GetInt32(3),
                            Administrator = Convert.ToBoolean(reader.GetInt32(4))
                        });
                    }
                }
            );


            return list;
        }
    }
}
