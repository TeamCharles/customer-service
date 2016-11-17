using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using customer_service.Models;
using customer_service.Data;
using System.Text.RegularExpressions;

namespace customer_service
{

    /**
     * Class: EmployeeFactory
     * Purpose: Holds a singleton and can Get a single or get all employees
     * Author: Matt Hamil
     * Methods:
     *     Employee get(int EmployeeId) - Gets an employee ID
     *     List<Employee> getAll() - Gets all employees
     */
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


        /**
         * Purpose: Gets a single employee from database
         * Arguments:
         *     EmployeeId - An Employee ID
         * Return:
         *     Single employee from database
         */
        public Employee get(int EmployeeId)
        {
            BangazonWorkforceConnection conn = new BangazonWorkforceConnection();
            Employee e = null;

            conn.execute(@"SELECT 
                EmployeeId,
                FirstName, 
                LastName, 
                DepartmentId,
                Administrator
                FROM Employee
                WHERE EndDate IS NULL AND EmployeeId = " + EmployeeId, (SqliteDataReader reader) => {
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


        /**
         * Purpose: Gets all employee records from database
         * Return:
         *     List of all employee records
         */
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

        public Employee getEmployeeByFullName(string fullName)
        {
            // Break the string into an array, whitespace as the delimiter
            string[] fullNameAsArray = Regex.Split(fullName, @"\s+").Where(s => s != string.Empty).ToArray();
            string firstName = fullNameAsArray[0];
            string lastName = fullNameAsArray[1];

            BangazonConnection conn = new BangazonConnection();
            Employee e = null;

            conn.execute(@"SELECT 
                EmployeeId,
                FirstName, 
                LastName, 
                DepartmentId,
                Administrator
                FROM Employee
                WHERE FirstName = '" + firstName + "' AND " + "LastName = '" + lastName + "'",  // pls no sql hacks :(
                (SqliteDataReader reader) => {
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
    }
}
