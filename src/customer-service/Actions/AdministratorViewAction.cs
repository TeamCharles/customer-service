using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customer_service.Models;

namespace customer_service
{

    /**
     * Class: AdministratorViewAction
     * Purpose: Provide a View to Administrator Users that lists per Employee the # of Open Incidents and the Avg # of Close Incidents per Month
     * Author: Matt Kraatz
     * Methods:
     *     void ReadInput() - Calculates Incident statistics per Employee and prints a View to the Console
     */
    public class AdministratorViewAction
    {

        /**
         * Purpose: Calculates Incident statistics per Employee and prints a View to the Console
         * Arguments:
         *     void
         * Return:
         *     void
         */
        public static void ReadInput()
        {
            // Get All Incidents
            var incFact = new IncidentFactory();
            List<Incident> incidents = incFact.getAll();

            // Get All Employees
            var empFact = new EmployeeFactory();
            List<Employee> employees = empFact.getAll();

            // Create Dictionary for Results
            var output = new Dictionary<string, Tuple<int, int>>();
            employees.ForEach(delegate(Employee emp)
            {
                // Calculate # of Months this Employee has had Incidents
                int activeMonths = ((incidents.Max(i => i.DateCreated).Year - incidents.Min(i => i.DateCreated).Year) * 12) + (incidents.Max(i => i.DateCreated).Month - incidents.Min(i => i.DateCreated).Month);
                // Count # of Open Incidents for this Employee
                int open = incidents.Where(i => i.EmployeeId == emp.EmployeeId).Count(i => i.DateResolved == null);
                int avgClosed;
                // Calculate Average # of Closed Incidents for this Employee
                if (activeMonths == 0)
                {
                    avgClosed = incidents.Where(i => i.EmployeeId == emp.EmployeeId).Count(i => i.DateResolved != null);
                } else
                {
                    avgClosed = incidents.Where(i => i.EmployeeId == emp.EmployeeId).Count(i => i.DateResolved != null) / activeMonths;
                }
                // Add a record to the Dictionary with Employee's Name, Open Incidents, Avg Closed Incidents
                output.Add($"{emp.LastName}, {emp.FirstName}", new Tuple<int, int>(open,avgClosed));
            });

            Console.WriteLine(@"
******************************************************
*                                                    *
*                 INCIDENTS REPORT                   *
*                                                    *
******************************************************

Representative                Open        Closed/Month
======================================================");

            // Print each Employee's Row to the Console
            foreach (KeyValuePair<string, Tuple<int, int>> entry in output)
            {
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < 32 - entry.Key.Count(); i++)
                {
                    buffer.Append(" ");
                }
                Console.WriteLine($"{entry.Key}{buffer}{entry.Value.Item1}                  {entry.Value.Item2}");
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }
    }
}
