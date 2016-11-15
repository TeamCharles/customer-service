using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using customer_service.Models;
using customer_service.Data;

namespace customer_service.Factories
{
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
        public List<Order> getAllOrderFromCustomers(int CustomerId)
        {
            BangazonConnection conn = new BangazonConnection();
            List<Order> OrderList = new List<Order>();

            //Execute de query to retrieve all customers
            conn.execute(@"select 
				OrderId,
			    Date,  
				DateCreated, 
				CustomerId,  
				from orders
                where CustomerId =" + CustomerId,
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        OrderList.Add(new Order
                        {
                            OrderId = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            DateCreated = reader.GetDateTime(2),
                            CustomerId = reader.GetInt32(2)
                        });
                    }
                }
            );

            return OrderList;

        }
    }
}
