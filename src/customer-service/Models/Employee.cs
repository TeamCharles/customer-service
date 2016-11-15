using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using customer_service.Data;

namespace customer_service.Models
{

    /**
     * Class: Employee
     * Purpose: Represents the Employee table in the database
     * Author: Team Charles
     * Methods:
     *     void save() - Saves employee object to the database
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


        /**
         * Purpose: Prints Employee properties
         * Return:
         *     String with employee properties
         */
        public override string ToString()
        {
            return string.Format($"[Employee: EmployeeId={EmployeeId}, FirstName={FirstName}, LastName={LastName}, DepartmentId={DepartmentId}, Administrator={Administrator}");
        }

        public void save()
        {
            string query = string.Format(@"
            INSERT INTO Employee 
                (FirstName, LastName, DepartmentId, Administrator)
            VALUES 
                ('{0}', '{1}', '{2}', '{3}');
            ",
                this.FirstName,
                this.LastName,
                this.DepartmentId,
                this.Administrator
            );

            BangazonConnection conn = new BangazonConnection();
            conn.insert(query);
        }
    }
}
