using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: Employee
     * Purpose: Represents the Employee table in the database
     * Author: Team Charles
     */
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public bool Administrator { get; set; }

        // Foreign Key Dependencies
        public ICollection<Incident> Incidents;

    }
}
