using customer_service.Models;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace customer_service
{
    /**
     * Class: ShowSingleIncidentAction
     * Purpose: Displays the menu and details for the single incident report
     * Author: Dayne Wright
     * Methods:
     *     void ReadInput() - Shows the incident report and prompts for a resolution if one is not provided. 
     *     Then saves that resolution with the current date.
     */

    public class ShowSingleIncidentAction
    {
        /**
         * Purpose: Shows incident report and saves resolution if needed.
         * Arguments:
         *     NONE
         * Return:
         *     Void
         */
        public static void ReadInput()
        {
            Customer customer = CustomerFactory.Instance.ActiveCustomer;
            Incident incident = IncidentFactory.Instance.ActiveIncident;

            if (customer == null || incident == null)
            {
                Console.WriteLine("A customer or incident could not be found.");
                Console.Write("> ");
                Console.ReadLine();
            }
            else
            {
                LabelFactory labelFactory = new LabelFactory();
                IncidentTypeFactory typesFactory = new IncidentTypeFactory();

                var labels = labelFactory.GetLabels(incident.IncidentTypeId);
                var types = typesFactory.getAll();

                Console.Write("\n");
                Console.WriteLine("INCIDENT");
                Console.WriteLine("==============================================================");
                Console.WriteLine($"Customer: {customer.FirstName}, {customer.LastName}                         Order: {incident.OrderId}");
                Console.WriteLine($"Incident Type: {types[incident.IncidentTypeId].Label}");
                Console.Write("\n");
                Console.WriteLine("Labels:");
                foreach (Label label in labels)
                {
                    Console.WriteLine($"* {label.Description}");  
                }
                Console.Write("\n");

                if (incident.Resolution == "" || incident.Resolution == null)
                {
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("Enter Resolution: ");
                    Console.Write("> ");

                    string returnedResolution = Console.ReadLine();

                    string[] quotes = Regex.Split(returnedResolution, @"""");

                    incident.Resolution = string.Join(@"\u0022", quotes);

                    incident.DateResolved = DateTime.Now;
                    incident.update();

                    Console.WriteLine($"Resolution saved to incident #{incident.IncidentId}");
                    Console.Write("> ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Resolution:");
                    Console.WriteLine(incident.Resolution);
                    Console.WriteLine("==============================================================");
                    Console.Write("> ");
                    Console.ReadLine();
                }
            }
        }
    }
}
