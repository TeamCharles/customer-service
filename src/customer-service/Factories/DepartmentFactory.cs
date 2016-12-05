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
     * Class: DepartmentFactory
     * Purpose: Holds a singleton and can get a single department or all departments
     * Author: Matt Hamil
     * Methods:
     *     Department get(int DepartmentId) - Gets a department ID
     *     List<Employee> getAll() - Gets all employees
     */
    public class DepartmentFactory
    {
        // Make the factory a singleton to maintain state across all uses
        private static DepartmentFactory _instance;
        public static DepartmentFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentFactory();
                }
                return _instance;
            }
        }

        // To track the currently active department
        private Department _activeDepartment = null;
        public Department ActiveDepartment
        {
            get
            {
                return _activeDepartment;
            }
            set
            {
                _activeDepartment = value;
            }
        }


        /**
         * Purpose: Gets a single department from database
         * Arguments:
         *     DepartmentId - A department ID
         * Return:
         *     Single department from database
         */
        public Department get(int DepartmentId)
        {
            BangazonWorkforceConnection conn = new BangazonWorkforceConnection();
            Department d = null;

            conn.execute(@"SELECT 
                DepartmentId,
                Name
                FROM Department
                WHERE DepartmentId = " + DepartmentId, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    d = new Department
                    {
                        DepartmentId = reader.GetInt32(0),
                        Label = reader[1].ToString()
                    };
                }
            });


            return d;
        }


        /**
         * Purpose: Gets all deparments from database
         * Return:
         *     List of all department records
         */
        public List<Department> getAll()
        {
            BangazonWorkforceConnection conn = new BangazonWorkforceConnection();
            List<Department> list = new List<Department>();

            // Execute the query to retrieve all customers
            conn.execute(@"SELECT 
                DepartmentId,
                Name
                FROM Department",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        list.Add(new Department
                        {
                            DepartmentId = reader.GetInt32(0),
                            Label = reader[1].ToString()
                        });
                    }
                }
            );

            return list;
        }
    }
}
