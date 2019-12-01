namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisioners = context
                .Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(op => new
                    {
                        OfficerName = op.Officer.FullName,
                        Department = op.Officer.Department.Name
                    })
                    .OrderBy(op => op.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(y => Math.Round(y.Officer.Salary, 2))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(prisioners, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var searchedNames = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var prisioner =
                 context
                 .Prisoners
                 .Where(x => searchedNames.Contains(x.FullName))
                 .Select(x => new ExportPrisionerDto
                 {
                     Id = x.Id,
                     Name = x.FullName,
                     IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EncryptedMessages = x.Mails.Select(y => new MessageDto
                     {
                         Description = ReverseString(y.Description)
                     })
                     .ToArray()
                 })
                 .OrderBy(x => x.Name)
                 .ThenBy(x => x.Id)
                 .ToArray();

            var xmlSeriazlizer = new XmlSerializer(typeof(ExportPrisionerDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            xmlSeriazlizer.Serialize(new StringWriter(sb), prisioner, namespaces);

            return sb.ToString().TrimEnd();

        }

        private static string ReverseString(string stringInput)
        {
            var resultstring = new string(stringInput.ToCharArray().Reverse().ToArray());
            return resultstring;
        }
    }
}