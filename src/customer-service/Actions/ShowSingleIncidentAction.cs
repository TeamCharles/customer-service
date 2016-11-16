using customer_service.Models;
using System;
using System.Text;

namespace customer_service
{
    public class ShowSingleIncidentAction
    {
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
                    Console.ReadLine();  // WILL BE REMOVED BEFORE MERGE
                }
                else
                {
                    Console.WriteLine("Resolution:");
                    Console.WriteLine(incident.Resolution);
                    Console.WriteLine("==============================================================");
                    Console.Write("> ");
                    Console.ReadLine();  // WILL BE REMOVED BEFORE MERGE
                }
            }
        }
    }
}
