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
     * Class: Incident
     * Purpose: Represents the Incident table in the database
     * Author: Team Charles
     */
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int IncidentTypeId { get; set; }
        public IncidentType IncidentType { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string Resolution { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateResolved { get; set; }

        public void save()
        {
            string query = "INSERT INTO Incident (OrderId,EmployeeId,Resolution,DateResolved) "
                + $"VALUES ({this.OrderId},{this.EmployeeId},{this.Resolution},{this.DateResolved})";
            BangazonConnection conn = new BangazonConnection();
            conn.insert(query);
        }

        public void update()
        {
            string query = $"UPDATE Incident SET Resolution = {this.Resolution}, DateResolved = {this.DateResolved}"
                + $"WHERE IncidentId = ${this.IncidentId}";
            BangazonConnection conn = new BangazonConnection();
            conn.insert(query);
        }
    }
}
