namespace ProductShop.Dtos.Export
{
    using System;
    using System.Xml.Serialization;

    public class ExportCustomUserProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserAndProductDto[] Users { get; set; }
    }
}
