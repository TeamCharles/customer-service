using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
