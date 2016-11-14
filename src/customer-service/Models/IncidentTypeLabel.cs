using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: IncidentTypeLabel
     * Purpose: Represents the IncidentTypeLabel table in the database
     * Author: Team Charles
     */
    public class IncidentTypeLabel
    {
        [Key]
        public int IncidentTypeLabelId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int IncidentTypeId { get; set; }
        public IncidentType IncidentType { get; set; }

        [Required]
        public int LabelId { get; set; }
        public Label Label { get; set; }
    }
}
