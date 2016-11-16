using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using customer_service.Models;
using customer_service.Data;

namespace customer_service.Factories
{

    /**
+     * Class: OrderFactory
+     * Purpose: Creates a connection between the database and the user to retrieve every order for the required customer
+     * Author: Anulfo Ordaz
+     * Methods:
+     *     
+     *     public static OrderFactory Instance - creates an instance of the order factory
+     *     public List<Order> getAllOrdersFromCustomer(int customerId) - Make a public list that holds the orders for a selected customer
            public DateTime ParseDate(string date) - Takes the string that represents the date when the order was completed and parse it into DateTime format
+     */
    public class OrderFactory
    {
        //Make an order factory singleton to maintain state accross all uses

        private static OrderFactory _instance;

        public static OrderFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderFactory();
                }
                return _instance;
            }
        }

        //Make a public list that hold that customer orders by id
        public List<Order> getAllOrdersFromCustomer(int customerId)
        {
            BangazonConnection conn = new BangazonConnection();
            List<Order> OrderList = new List<Order>();

            //Execute de query to retrieve all customers
            conn.execute(@"select 
				OrderId,
			    ""Date"",  
				DateCreated, 
				CustomerId  
				from ""Order""
                where CustomerId =" + customerId,
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        OrderList.Add(new Order
                        {
                            OrderId = reader.GetInt32(0),
                            Date = ParseDate(reader[1].ToString()),
                            DateCreated = reader.GetDateTime(2),
                            CustomerId = reader.GetInt32(3)
                        });
                    }
                }
            );

            return OrderList;

        }

        //Takes the string that represents the date when the order was completed and parse it into DateTime format
        public DateTime ParseDate(string date)
        {
                 var array = new int[3];
                 array[0] = Int32.Parse(date.Substring(0, 4));
                 array[1] = Int32.Parse(date.Substring(4, 2));
                 array[2] = Int32.Parse(date.Substring(6, 2));
                 return new DateTime(array[0], array[1], array[2]);
        }
    }
}
