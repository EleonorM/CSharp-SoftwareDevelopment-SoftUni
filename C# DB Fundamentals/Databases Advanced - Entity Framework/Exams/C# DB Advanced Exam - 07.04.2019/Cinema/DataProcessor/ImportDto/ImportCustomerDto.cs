using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
   public class ImportCustomerDto
    {
        [Required]
        [MaxLength(20), MinLength(3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("Balance")]
        [Range(0.01, (double)decimal.MaxValue)]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketDto[] Tickets { get; set; }

    }

    [XmlType("Ticket")]
    public class TicketDto
    {
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }

        [Range(0.01, (double)decimal.MaxValue)]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
