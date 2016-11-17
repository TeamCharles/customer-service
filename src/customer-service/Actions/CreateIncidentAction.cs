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
            List<Customer> customerList = customerFactory.getAll();
            List<Incident> incidents = incidentFactory.getAll();
            Incident incident = new Incident();
            incident.DateCreated = DateTime.Now;

            Console.WriteLine("Please select a customer from the following list to find active orders:");
            Console.WriteLine("***********************************************************************");


            foreach (Customer customer in customerList)
            {
                Console.WriteLine($"{customer.CustomerId} { customer.FirstName} {customer.LastName} ");
            }
            Console.WriteLine("***********************************************************************");

            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please select one of the following Order IDs to add an incident:");
            Console.WriteLine("***********************************************************************");
            List<Order> orderList = orderFactory.getAllOrdersFromCustomer(customerId);
            foreach (Order order in orderList)
            {
                Console.WriteLine($"{order.OrderId} { order.Date}");

            }
            Console.WriteLine("***********************************************************************");


            while (incident.OrderId < 0)
            {
                try
                {
                    incident.OrderId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error! Please enter a number corresponding to a proper Order Id: ");
                }
            }

            while (incident.EmployeeId <= 0)
            {
                Console.WriteLine("Enter the Employee Id: ");
                try
                {
                    incident.EmployeeId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error! Please enter a number corresponding to a proper Employee Id: ");
                }
            }

            while (incident.IncidentTypeId <= 0)
            {
                Console.WriteLine("Enter the Incident Type ID. Your options are the following: ");
                try
                {
                    incident.IncidentTypeId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error! Please enter a number corresponding to a proper Incident Type Id: ");
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
                    incident.DateResolved = DateTime.Now;
                }
                break;
            }

            incident.save();
            Console.WriteLine($"Incident # {incidents.Count } has been added. Press any key to return to main menu.");
            Console.ReadLine();


        }
    }
}
