namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context
                .Genres
               .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(y => y.Purchases.Any())
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToArray(),
                    TotalPlayers = x.Games.Sum(y => y.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var purchaseType = Enum.Parse<PurchaseType>(storeType);

            var users =
                 context
                 .Users
                 .Select(x => new ExportUsersDto
                 {
                     Username = x.Username,
                     Purchases = x.Cards.SelectMany(y => y.Purchases)
                     .Where(y=>y.Type == purchaseType)
                     .Select(c => new PurchaseDto
                     {
                         CardNumber = c.Card.Number,
                         Cvc = c.Card.Cvc,
                         Date = c.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                         Game = new GameDto
                         {
                             Genre = c.Game.Genre.Name,
                             Price = c.Game.Price,
                             Title = c.Game.Name
                         }
                     })
                     .OrderBy(p=>p.Date)
                     .ToArray(),
                     TotalSpent = x.Cards.SelectMany(y => y.Purchases)
                       .Where(y => y.Type == purchaseType)
                     .Sum(z => z.Game.Price)
                 })
                 .Where(x=>x.Purchases.Any())
                 .OrderByDescending(x => x.TotalSpent)
                 .ThenBy(x => x.Username)
                 .ToArray();

            var xmlSeriazlizer = new XmlSerializer(typeof(ExportUsersDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            xmlSeriazlizer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}