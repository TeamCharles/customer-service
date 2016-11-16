using System;
using Microsoft.Data.Sqlite;
using customer_service.Data;
using customer_service.Models;

namespace customer_service
{
    /**
     * Class: CustomerFactory
     * Purpose: Creates a connection between the database and the user to grab individual customers
     * Author: Garrett
     * Methods:
     *     
     *     public static CustomerFactory Instance - creates an instance of the customer factory
     *     public Customer ActiveCustomer - This method sets an active customer for the program
     *      public Customer get(int CustomerId) - This method returns a customer from the database.
     */
    public class CustomerFactory
    {
        /**
        * Purpose: Create instance of the customer factory
        * Arguments:
        *     n/a
        * Return:
        *     n/a 
        */
        private static CustomerFactory _instance;
        public static CustomerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerFactory();
                }
                return _instance;
            }
        }
        /**
        * Purpose: Sets an active customer 
        * Arguments:
        *     n/a
        * Return:
        *     n/a 
        */
        private Customer _activeCustomer = null;
        public Customer ActiveCustomer
        {
            get
            {
                return _activeCustomer;
            }
            set
            {
                _activeCustomer = value;
            }
        }
        /**
         * Purpose: returns a customer from the database
         * Arguments:
         *     int CustomerId
         * Return:
         *     Desidred customer that matches customerId
         */
        public Customer get(int CustomerId)
        {
            BangazonConnection conn = new BangazonConnection();
            Customer c = null;

            conn.execute(@"select 
				CustomerId,
				FirstName, 
				LastName
				from customer
				where CustomerId = " + CustomerId, (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    c = new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString()
                    };
                }
            });

            return c;
        }
    }
}
