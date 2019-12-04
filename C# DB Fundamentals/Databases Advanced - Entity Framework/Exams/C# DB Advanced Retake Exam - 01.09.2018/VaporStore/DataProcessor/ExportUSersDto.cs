namespace VaporStore.DataProcessor
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUsersDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public PurchaseDto[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }

    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [XmlElement("PurchaseType")]
        public string PurchaseType { get; set; }

        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [XmlElement]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public GameDto Game { get; set; }
    }

    public class GameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
