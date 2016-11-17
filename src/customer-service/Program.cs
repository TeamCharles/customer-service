using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using customer_service.Models;
using customer_service.Actions;

namespace customer_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();

            Employee activeEmployee = employeeFactory.get(2);

            EmployeeFactory.Instance.ActiveEmployee = activeEmployee;

            MainMenu.ReadInput();
        }
    }
}
