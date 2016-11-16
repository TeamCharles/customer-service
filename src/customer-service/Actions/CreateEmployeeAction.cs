using customer_service;
using customer_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace customer_service.Actions
{

    /**
     * Class: CreateEmployeeAction
     * Purpose: Prompts the user for information about a new employee and saves to DB
     * Author: Matt Hamil
     * Methods:
     *     static void ReadInput() - Prompts for employee info and saves to DB
     */
    public class CreateEmployeeAction
    {
        /**
         * Purpose: Reads user input for new employee information
         * Return:
         *     void
         */
        public static void ReadInput()
        {
            Employee newEmployee = new Employee();
            DepartmentFactory departmentFactory = new DepartmentFactory();
            EmployeeFactory employeeFactory = new EmployeeFactory();

            while (newEmployee.FirstName == null || newEmployee.FirstName.Length <= 0)
            {
                Console.WriteLine("Enter employee first name and hit return: ");
                newEmployee.FirstName = Console.ReadLine();
            }

            while (newEmployee.LastName == null || newEmployee.LastName.Length <= 0)
            {
                Console.WriteLine("Enter customer last name and hit return: ");
                newEmployee.LastName = Console.ReadLine();
            }

            List<Department> allDepartments = departmentFactory.getAll();

            while (newEmployee.DepartmentId <= 0 || allDepartments.TrueForAll(d => d.DepartmentId != newEmployee.DepartmentId))
            {
                Console.WriteLine("\nAll Departments:");

                foreach (Department d in allDepartments)
                {
                    Console.WriteLine(d.DepartmentId + ". " + d.Label);
                }
                Console.WriteLine("Enter department ID: ");

                try
                {
                    newEmployee.DepartmentId = Convert.ToInt32(Console.ReadLine());
                    if (allDepartments.TrueForAll(d => d.DepartmentId != newEmployee.DepartmentId))
                    {
                        Console.WriteLine("Error! Please enter a number corresponding to the employee's department ID: ");
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Please enter a number corresponding to the employee's department ID: ");
                }
            }

            Console.WriteLine($"Is {newEmployee.FirstName} {newEmployee.LastName} an administrator? Enter YES or NO: ");
            string administratorInput = Console.ReadLine();

            while (administratorInput.ToUpper() != "YES" && administratorInput.ToUpper() != "NO")
            {
                Console.WriteLine($"I'm sorry, I'm not sure I know what you mean by {administratorInput}. Try again. ");
                administratorInput = Console.ReadLine();
            }

            if (administratorInput.ToUpper() == "YES")
            { 
                newEmployee.Administrator = true;
            }
            else
            {
                newEmployee.Administrator = false;
            }

            newEmployee.save();

            Employee newlySavedEmployee = employeeFactory.getAll().Last();

            Console.WriteLine(newlySavedEmployee.ToString());

            EmployeeFactory.Instance.ActiveEmployee = newlySavedEmployee;

            Console.WriteLine($"{newlySavedEmployee.FirstName} {newlySavedEmployee.LastName} added. Press any key to return to main menu.");
            Console.ReadLine();
        }
    }
}
