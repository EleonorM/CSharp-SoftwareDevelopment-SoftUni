namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisionersMailsDto
    {
        [Required]
        [MaxLength(20), MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("The [A-Z][a-z]+")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailDto[] Mails { get; set; }

    }

    public class MailDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"[\w| | 0-9]+ str.$")]
        public string Address { get; set; }

    }
}
