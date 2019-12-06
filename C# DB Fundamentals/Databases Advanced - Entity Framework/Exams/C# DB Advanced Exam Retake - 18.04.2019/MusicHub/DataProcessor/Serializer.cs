namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var prisioners = context
                 .Albums
                 .Where(x => x.ProducerId == producerId)
                 .OrderByDescending(x => x.Songs.Sum(s => s.Price))
                 .Select(x => new
                 {
                     AlbumName = x.Name,
                     ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                     ProducerName = x.Producer.Name,
                     Songs = x.Songs.Select(s => new
                     {
                         SongName = s.Name,
                         Price = s.Price.ToString("f2"),
                         Writer = s.Writer.Name
                     })
                     .OrderByDescending(s => s.SongName)
                     .ThenBy(s => s.Writer)
                     .ToArray(),

                     AlbumPrice = x.Songs.Sum(s => s.Price).ToString("f2")
                 })
                 .ToArray();

            var jsonResult = JsonConvert.SerializeObject(prisioners, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var prisioner =
                 context
                 .Songs
                 .Where(x => x.Duration.TotalSeconds > duration)
                 .Select(x => new ExportSongsDto
                 {
                     SongName = x.Name,
                     Writer = x.Writer.Name,
                     Duration = x.Duration.ToString("c"),
                     AlbumProducer = x.Album.Producer.Name,
                     Performer = x.SongPerformers.Select(y => $"{y.Performer.FirstName} {y.Performer.LastName}").FirstOrDefault()
                 })
                 .OrderBy(x => x.SongName)
                 .ThenBy(x => x.Writer)
                 .ThenBy(x => x.Performer)
                 .ToArray();

            var xmlSeriazlizer = new XmlSerializer(typeof(ExportSongsDto[]), new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            xmlSeriazlizer.Serialize(new StringWriter(sb), prisioner, namespaces);

            return sb.ToString().TrimEnd();
            throw new NotImplementedException();
        }
    }
}