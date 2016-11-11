using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customer_service.Models
{

    /**
     * Class: Customer
     * Purpose: Represents the Customer table in the database
     * Author: Team Charles
     */
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // Foreign Key Dependencies
        public ICollection<Order> Orders;

    }
}
