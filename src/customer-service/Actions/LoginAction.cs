using customer_service;
using customer_service.Models;
using System;

namespace customer_service.Actions
{

    /**
     * Class: CreateEmployeeAction
     * Purpose: Prompts the user for employee name to log in
     * Author: Matt Hamil
     * Methods:
     *     static void ReadInput() - Prompts for employee name and sets logged in employee
     */
    public class LoginAction
    {
        /**
         * Purpose: Reads user input for new employee information
         * Return:
         *     void
         */
        public static void ReadInput()
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();

            string employeeName = string.Empty;

            Console.WriteLine("Enter your first and last name to start.Type \"new user\" to create a new user account.");

            while (employeeName != "new user")
            {
                employeeName = Console.ReadLine();

                if (employeeName.Contains(" ") == false && !String.IsNullOrEmpty(employeeName))
                {
                    Console.WriteLine("Please enter first and last name.");
                    continue;
                }

                if (employeeName.ToLower() == "new user") { break; }

                var loggedInEmployee = employeeFactory.getEmployeeByFullName(employeeName);

                if (loggedInEmployee != null)
                {
                    EmployeeFactory.Instance.ActiveEmployee = loggedInEmployee;
                    break;
                }
                else
                {
                    Console.WriteLine($"Could not find employee with name {employeeName}. Type \"new user\" to create a new user account.");
                }

            }

            if (employeeName.ToLower() == "new user")
            {
                CreateEmployeeAction.ReadInput();
            }

            Console.WriteLine($"Welcome {EmployeeFactory.Instance.ActiveEmployee.FirstName} {EmployeeFactory.Instance.ActiveEmployee.LastName}! Press ENTER to go to the main menu.");
            Console.ReadLine();
        }
    }
}