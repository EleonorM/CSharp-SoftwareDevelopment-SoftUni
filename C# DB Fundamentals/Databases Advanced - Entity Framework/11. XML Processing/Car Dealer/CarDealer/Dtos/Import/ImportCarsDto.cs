namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ImportPartCarDto[] CarParts { get; set; }
    }

    [XmlType("partId")]
    public class ImportPartCarDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }

        public int CarId { get; set; }
    }
}
