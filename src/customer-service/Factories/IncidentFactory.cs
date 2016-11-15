using System;
using Microsoft.Data.Sqlite;
using customer_service.Data;
using customer_service.Models;

namespace customer_service.Factories
{
    public class IncidentFactory
    {
        private static IncidentFactory _instance;
        public static IncidentFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncidentFactory();
                }
                return _instance;
            }
        }
    }
}
