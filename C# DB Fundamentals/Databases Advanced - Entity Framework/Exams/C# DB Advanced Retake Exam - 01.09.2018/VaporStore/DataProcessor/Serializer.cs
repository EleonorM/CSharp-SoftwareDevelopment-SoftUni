namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context
                .Genres
                .Where(x => x.Games.Select(x=>x.Purchases.Any()))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags),
                        Players = g.Purchases.Count
                    })
                    .ToArray(),
                })

                .OrderByDescending(g => g.Games.Sum(x => x.Players))
                .ThenBy(x => x.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            throw new NotImplementedException();
        }
    }
}