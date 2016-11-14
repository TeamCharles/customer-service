using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: IncidentType
     * Purpose: Represents the IncidentType table in the database
     * Author: Team Charles
     */
    public class IncidentType
    {
        [Key]
        public int IncidentTypeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Label { get; set; }

        // Foreign Key Dependencies
        public ICollection<IncidentTypeLabel> IncidentTypeLabels;

    }
}
