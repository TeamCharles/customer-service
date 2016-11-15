using System;
using Microsoft.Data.Sqlite;
using customer_service.Data;
using customer_service.Models;

namespace customer_service.Factories
{
    public class CustomerFactory
    {
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
