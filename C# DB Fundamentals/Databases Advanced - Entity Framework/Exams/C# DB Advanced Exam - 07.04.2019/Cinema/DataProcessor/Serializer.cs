namespace Cinema.DataProcessor
{
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                 .Movies
                 .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Count > 0))
                 .OrderByDescending(m => m.Rating)
                  .ThenByDescending(m => m.Projections.Sum(y => y.Tickets.Sum(t => t.Price)))
                 .Select(x => new
                 {
                     MovieName = x.Title,
                     Rating = x.Rating.ToString("f2"),
                     TotalIncomes = x.Projections.Sum(y => y.Tickets.Sum(t => t.Price)).ToString("f2"),
                     Customers = x.Projections
                     .SelectMany(y => y.Tickets)
                     .Select(t => new
                     {
                         FirstName = t.Customer.FirstName,
                         LastName = t.Customer.LastName,
                         Balance = t.Customer.Balance.ToString("f2")
                     })
                     .OrderByDescending(c => c.Balance)
                     .ThenBy(c => c.FirstName)
                     .ThenBy(c => c.LastName)
                     .ToArray()
                 })


                .Take(10)
                 .ToArray();

            var jsonResult = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }


        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers =
                  context
                  .Customers
                  .Where(x => x.Age >= age)
                  .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                  .Select(x => new ExportCuromerDto
                  {
                      FirstNsame = x.FirstName,
                      LastName = x.LastName,
                      SpentMoney = (x.Tickets.Sum(t => t.Price)).ToString("f2"),
                      SpentTime =  TimeSpan.FromMilliseconds (x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds)).ToString(@"hh\:mm\:ss")
                  })
                  .Take(10)
                  .ToArray();

            var xmlSeriazlizer = new XmlSerializer(typeof(ExportCuromerDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            xmlSeriazlizer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}