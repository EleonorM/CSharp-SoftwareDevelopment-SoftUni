using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisionerDto
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string IncarcerationDate { get; set; }

        [XmlArray]
        public MessageDto[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class MessageDto
    {
        [XmlElement]
        public string Description { get; set; }
    }
}
