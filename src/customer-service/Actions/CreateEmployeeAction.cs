using customer_service;
using customer_service.Models;
using System;

namespace customer_service.Actions
{
    public class CreateEmployeeAction
    {
        public static void ReadInput()
        {
            Employee newEmployee = new Employee();

            while (newEmployee.FirstName == null || newEmployee.FirstName.Length <= 0)
            {
                Console.WriteLine("Enter employee first name: ");
                newEmployee.FirstName = Console.ReadLine();
            }

            while (newEmployee.LastName == null || newEmployee.LastName.Length <= 0)
            {
                Console.WriteLine("Enter customer last name: ");
                newEmployee.LastName = Console.ReadLine();
            }

            while (newEmployee.DepartmentId <= 0)
            {
                Console.WriteLine("Enter department ID: ");
                try
                {
                    newEmployee.DepartmentId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error! Please enter a number corresponding to the employee's department ID: ");
                }
            }

            Console.WriteLine($"Is {newEmployee.FirstName} {newEmployee.LastName} an administrator? Enter YES or NO: ");
            string administratorInput = Console.ReadLine();

            while (administratorInput.ToUpper() != "YES" && administratorInput.ToUpper() != "NO" )
            {
                Console.WriteLine($"I'm sorry, I'm not sure I know what you mean by {administratorInput}. Try again. ");
                administratorInput = Console.ReadLine();
            }

            Console.WriteLine(newEmployee.ToString());

            newEmployee.save();

            EmployeeFactory.Instance.ActiveEmployee = newEmployee;

            Console.WriteLine($"{newEmployee.FirstName} {newEmployee.LastName} added. Press any key to return to main menu.");
            Console.ReadLine();
        }
    }
}
