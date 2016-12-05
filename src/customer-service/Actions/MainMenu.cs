using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_service.Actions;


namespace customer_service
{
    /**
     * Class: MainMenuAction
     * Purpose: Makes a view for the employee that allows to route to the CreateIncident Action, the ListIncidents Action and if the user is an Admin to AdministratorView Action.  
     * Author: Anulfo Ordaz//Matt Kraatz
     * Methods:
     *     public static void ReadInput() - Promt a list of options that get the user to CreateIncidentAction, ListIncidentsAction and AdministratorView Action.
     */
    public class MainMenu
    {

        public static void ReadInput()
        {
            string input = null;
            //A while loop that expects the user input 
            while (input == null || input.ToLower() != "x" )
            {
                Console.WriteLine(@"
*********************************************
*                                           *
*   BANGAZON INC CUSTOMER SERVICE PORTAL    *
*                                           *
*********************************************
1.Create Incident
2.List my Incidents");

                var acceptableInputs = new List<int> { 1, 2 };
                //checks if the Active User is an Admin, and if it is, prints the third option that leads to AdministratorViewAction
                if (EmployeeFactory.Instance.ActiveEmployee.Administrator)
                {
                    Console.WriteLine(@"3.Incident Report");
                    acceptableInputs.Add(3);
                }
                Console.WriteLine(@"X.Exit");
                input = Console.ReadLine();
                try {

                    //convert input to an integer and save it in variable selection
                    int selection = Convert.ToInt32(input);
                    //If selection match any of the accptable inputs reroute to the respective Action
                    if (acceptableInputs.Contains(selection))
                    {
                        if (selection == 1)
                        {
                            CreateIncidentAction.ReadInput();
                        }
                        if (selection == 2)
                        {
                            ListIncidentsAction.ReadInput();
                        }
                        if (selection == 3)
                        {
                            AdministratorViewAction.ReadInput();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select a number from the options above");
                    }
                }
                catch
                {
                    Console.WriteLine("Please select a number from the options above");
                };

            }
        }
    }

}
