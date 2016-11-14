using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: Department
     * Purpose: Represents the Department table in the database
     * Author: Team Charles
     */
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Label { get; set; }

        // Foreign Key Dependencies
        public ICollection<Employee> Employees;

    }
}
