using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: Order
     * Purpose: Represents the Order table in the database
     * Author: Team Charles
     */
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Foreign Key Dependencies
        public ICollection<Incident> Incidents;

    }
}
