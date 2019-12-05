namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        public int Age { get; set; }

        [Range(0.01, (double)decimal.MaxValue)]

        public decimal Balance { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
