using customer_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Actions
{
    public class CreateIncidentAction
    {
        public CreateIncidentAction()
        {

        }

        public static void ReadInput()
        {
            IncidentFactory incidentFactory = new IncidentFactory();
            List<Incident> incidents = incidentFactory.getAll();
            Incident incident = new Incident();
            incident.DateCreated = DateTime.Now;

            while (incident.OrderId <= 0)
            {
                Console.WriteLine("Enter the Order Id: ");
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
