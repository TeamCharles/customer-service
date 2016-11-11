using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: Label
     * Purpose: Represents the Label table in the database
     * Author: Team Charles
     */
    public class Label
    {
        [Key]
        public int LabelId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Description { get; set; }

        // Foreign Key Dependencies
        public ICollection<IncidentTypeLabel> IncidentTypeLabels;

    }
}
