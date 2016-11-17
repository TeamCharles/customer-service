using customer_service.Factories;
using customer_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Actions
{
    public class CreateIncidentAction
    {
        /**
         * Class: CreateIncidentAction
         * Purpose: Prompts the user for information about a new incident and saves that incident to the database
         * Author: Garrett Vangilder
         * Methods:
         *     static void ReadInput() - Prompts for incident info and saves to DB
         */
        public CreateIncidentAction()
        {

        }
        /**
        * Purpose: Reads user input for new incident information
        * Return:
        *     void
        */
        public static void ReadInput()
        {
            IncidentFactory incidentFactory = new IncidentFactory();
            CustomerFactory customerFactory = new CustomerFactory();
            OrderFactory orderFactory = new OrderFactory();
            IncidentTypeFactory incidentTypeFactory = new IncidentTypeFactory();
            List<IncidentType> incidentTypeList = incidentTypeFactory.getAll();
            List<Customer> customerList = customerFactory.getAll();
            List<Incident> incidents = incidentFactory.getAll();
            Incident incident = new Incident();
            incident.DateCreated = DateTime.Now;

            Console.WriteLine("Enter the customers first and last name to start:");
            Console.WriteLine("***********************************************************************");


            foreach (Customer customer in customerList)
            {
                Console.WriteLine($"{customer.CustomerId} { customer.FirstName} {customer.LastName} ");
            }
            Console.WriteLine("***********************************************************************");

            string customerName = Console.ReadLine();
            Customer customerId = customerFactory.getCustomerByFullName(customerName);

            while (customerId == null)
            {
                customerId = customerFactory.getCustomerByFullName(customerName);
                if (customerId == null)
                {
                    Console.WriteLine("This is not a valid answer. Please try again!");
                    customerName = Console.ReadLine();
                }
            }

            int orderID = 0;

                Console.WriteLine("Choose a customer order:");
                List<Order> orderList = orderFactory.getAllOrdersFromCustomer(customerId.CustomerId);
                foreach (Order order in orderList)
                {
                    Console.WriteLine($"Order {order.OrderId}: { order.Date}");

                }
                Console.WriteLine("X.Exit");
            while (orderID < 0)
            {
                string orderIDAnswer = Console.ReadLine();
                if (orderIDAnswer.ToLower() == "x")
                {
                    return;
                    // to main menu
                }
                try
                {
                    orderID = Convert.ToInt32(orderIDAnswer);
                }
                catch
                {
                    Console.WriteLine("Please enter an order number.");
                }
            }



            while (incident.OrderId <= 0 || orderList.TrueForAll(o => incident.OrderId != orderID))
            {
                if (orderList.Find(o => o.OrderId == orderID) != null)
                {
                    break;
                }

                if (orderList.TrueForAll(o => incident.OrderId != orderID) || orderID == 0)
                {
                    Console.WriteLine("This is not a valid answer. Try again!");
                    try
                    {
                        orderID = Convert.ToInt32(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number");
                    }
                }
            }
            incident.OrderId = orderID;

          
            Console.WriteLine("Choose incident type: ");
            foreach(IncidentType incidentType in incidentTypeList)
            {
                Console.WriteLine($"{incidentType.IncidentTypeId} {incidentType.Label}");
            }
            Console.WriteLine("X.Exit");
            int incidentTypeId = 0;
            while (incidentTypeId == 0)
            {
                string incidentTypeIdAnswer = Console.ReadLine();
                if (incidentTypeIdAnswer.ToLower() == "x")
                {
                    // to main menu
                    return;
                }
                try
                {
                     incidentTypeId = Convert.ToInt32(incidentTypeIdAnswer);
                }
                catch
                {
                    Console.WriteLine("This is not a valid answer. Try again!");
                }
            }



            while (incident.IncidentTypeId <= 0 || incidentTypeList.TrueForAll(o => incident.IncidentTypeId != incidentTypeId))
            {
                if (incidentTypeList.Find(it => it.IncidentTypeId == incidentTypeId) != null)
                {
                    break;
                }

                if (incidentTypeList.TrueForAll(o => incident.IncidentTypeId != incidentTypeId) || incidentTypeId == 0)
                {
                    Console.WriteLine("This is not a valid answer. Try again!");
                    try
                    {
                        incidentTypeId = Convert.ToInt32(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number");
                    }
                }
            }

            while (incident.Resolution == null)
            {
                string answer = "";
                while (answer != "y" || answer != "n")
                {
                    Console.WriteLine("Would you like to resolve this issue ? (y / n)");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "y" || answer == "n")
                    {
                        break;
                    }
                }
                if (answer == "y")
                {
                    Console.WriteLine("How was the incident resolved? ");
                    incident.Resolution = Console.ReadLine();
                    incident.DateResolved = DateTime.Today;
                }
                break;
            }

            incident.save();
            Console.WriteLine($"Incident # {incidents.Count } has been added. Press any key to return to main menu.");
            Console.ReadLine();


        }
    }
}
