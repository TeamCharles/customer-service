using System;
using Microsoft.Data.Sqlite;

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

        private CustomerFactory _activeCustomer = null;
        public CustomerFactory ActiveCustomer
        {

        }
    }
}
