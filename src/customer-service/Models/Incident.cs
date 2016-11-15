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
     * Purpose: Represents the Incident table in the database, allows for saving and updating of Incident rows
     * Author: Matt Kraatz
     * Methods:
     *      save() - inserts this Incident into the database via SQL
     *      update() - updates this Incident in the database via SQL
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


        /**
         * Purpose: Insert this Incident into the database via SQL
         * Arguments:
         *     void
         * Return:
         *     void
         */
        public void save()
        {
            string query;
            if (this.Resolution == null)
            {
                query = "INSERT INTO Incident (OrderId,EmployeeId,IncidentTypeId,Resolution,DateResolved) "
                    + $"VALUES ({this.OrderId},{this.EmployeeId},{this.IncidentTypeId},\"\",null)";
            } else
            {
                query = "INSERT INTO Incident (OrderId,EmployeeId,IncidentTypeId,Resolution,DateResolved) "
                    + $"VALUES ({this.OrderId},{this.EmployeeId},{this.IncidentTypeId},{this.Resolution},{this.DateResolved})";
            }
            BangazonConnection conn = new BangazonConnection();
            conn.insert(query);
        }


        /**
         * Purpose: Update this Incident in the database
         * Arguments:
         *     void
         * Return:
         *     void
         */
        public void update()
        {
            string query = $"UPDATE Incident SET Resolution = '{this.Resolution}', DateResolved = {this.DateResolved.Value.ToString("yyyyMMdd")} "
                + $"WHERE IncidentId = {this.IncidentId}";
            BangazonConnection conn = new BangazonConnection();
            conn.insert(query);
        }
    }
}
