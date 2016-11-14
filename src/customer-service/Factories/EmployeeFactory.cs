using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using customer_service.Models;

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
                Administrator,
                WHERE EmployeeId = " + EmployeeId, (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    e = new Employee
                    {
                        EmployeId = reader.GetInt32(0),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        DepartmentId = reader.GetInt32(3),
                        Administrator = reader[4].ToBool(),
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
				IdCustomer,
				FirstName,  
				LastName, 
				StreetAddress, 
				City, 
				StateProvince, 
				PostalCode, 
				PhoneNumber 
				FROM customer",
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        list.Add(new Customer
                        {
                            id = reader.GetInt32(0),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            StreetAddress = reader[3].ToString(),
                            City = reader[4].ToString(),
                            StateProvince = reader[5].ToString(),
                            PostalCode = reader[6].ToString(),
                            PhoneNumber = reader[7].ToString()
                        });
                    }
                }
            );


            return list;
        }
    }
}
