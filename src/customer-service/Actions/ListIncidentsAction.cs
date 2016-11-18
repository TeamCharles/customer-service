﻿using customer_service.Models;
using System;
using System.Collections.Generic;

namespace customer_service.Actions
{
    public class ListIncidentsAction
    {
        /**
         * Class: ListIncidentsAction
         * Purpose: Lists all incidents for the current employee
         * Author: Dayne Wright
         * Methods:
         *     static void ReadInput() - Shows the list of incidents and sets selected
         */
         public static void ReadInput()
        {
            Employee employee = EmployeeFactory.Instance.ActiveEmployee;

            CustomerFactory custFact = new CustomerFactory();
            OrderFactory orderFact = new OrderFactory();
            IncidentFactory incidentFact = new IncidentFactory();

            Console.WriteLine (@"
====================================
BANGAZON INC CUSTOMER SERVICE PORTAL
====================================");
            Console.WriteLine();

            List<Incident> incidents = incidentFact.getByEmployeeId(employee.EmployeeId);


            incidents.ForEach(delegate(Incident i)
            {
                Order order = orderFact.get(i.OrderId);
                Customer customer = custFact.get(order.CustomerId);

                Console.WriteLine($"{i.IncidentId}. {customer.LastName}, {customer.FirstName} : Order {order.OrderId}");
            });
            Console.WriteLine("X.Exit");
            Console.Write("> ");
            int selection = 0;

            while (selection == 0)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input.ToLower() == "x")
                    {
                        return; // to main menu

                    }

                    selection = Convert.ToInt32(input);

                    if (incidents.Find(i => i.IncidentId == selection).IncidentId == selection)
                    {
                        IncidentFactory.Instance.ActiveIncident = incidentFact.get(selection);
                        CustomerFactory.Instance.ActiveCustomer = custFact.get(orderFact.get(IncidentFactory.Instance.ActiveIncident.OrderId).CustomerId);
                        ShowSingleIncidentAction.ReadInput();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Sorry!  That is not a valid incident number.  Please select an incident from above.");
                    Console.Write("> ");
                }
                selection = 0;
            }     

        }
    }
}
