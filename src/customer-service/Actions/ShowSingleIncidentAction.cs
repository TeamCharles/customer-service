using customer_service.Data;
using customer_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customer_service
{
    public class ShowSingleIncidentAction
    {
        public static void ReadInput()
        {
            Customer customer = CustomerFactory.Instance.ActiveIncident;
            Incident incident = IncidentFactory.Instance.ActiveIncident;

            if (customer == null || incident == null)
            {
                Console.WriteLine("A customer or incident could not be found.");
            }
            else
            {
                LabelFactory label = LabelFactory.Instance;
                IncidentTypeFactory type = IncidentTypeFactory.Instance;

                string customerName = $"{customer.LastName}, {customer.FirstName}";
                string border = "==============================================================";

                StringBuilder incidentDisplay = new StringBuilder();
                incidentDisplay.AppendLine("INCIDENT");
                incidentDisplay.AppendLine("\n");
                incidentDisplay.AppendLine(border);
                incidentDisplay.AppendLine($"                            Order: {incident.OrderId}");
                incidentDisplay.AppendLine("\n");
                incidentDisplay.AppendLine($"Incident Type: {type.Label}");
                incidentDisplay.AppendLine("**  Welcome to Bangazon! Command Line Ordering System  **");
                incidentDisplay.AppendLine(border);
            }
        }
    }
}
