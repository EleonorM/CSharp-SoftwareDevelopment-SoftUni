namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        [Required]
        [MaxLength(20), MinLength(3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(18, 70)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        [XmlElement("NetWorth")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportPerformerSongDto[] PerformersSongs { get; set; }
    }


    [XmlType("Song")]
    public class ImportPerformerSongDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
