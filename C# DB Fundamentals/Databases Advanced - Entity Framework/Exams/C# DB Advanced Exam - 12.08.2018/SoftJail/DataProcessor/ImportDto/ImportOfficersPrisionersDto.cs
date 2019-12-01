namespace SoftJail.DataProcessor.ImportDto
{
    using SoftJail.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficersPrisionersDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Money")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisionerDto[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class ImportPrisionerDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
